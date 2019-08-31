namespace rec Fable.AST.Fable.TypeDefs

// This AST is for interop of .NET <-> JS and we will construct a TypeScript AST from this via typescript APIs

open Fable
open Fable.AST
//open FSharp.Compiler.SourceCodeServices
open System

type FSharpEntityType =
    | Interface

type EnumTypeKind = NumberEnumType | StringEnumType
type FunctionTypeKind = LambdaType of Type | DelegateType of Type list

type Type =
    | MetaType
    | Any
    | Unit
    | Boolean
    | Char
    | String
    | Regex
    | Number of NumberKind
    | EnumType of kind: EnumTypeKind * fullName: string
    | Option of genericArg: Type
    | Tuple of genericArgs: Type list
    | Array of genericArg: Type
    | List of genericArg: Type
    | FunctionType of FunctionTypeKind * returnType: Type
    | GenericParam of name: string
    | ErasedUnion of genericArgs: Type list
    | DeclaredType of FSharpEntityType * genericArgs: Type list
    | AnonymousRecordType of fieldNames: string[] * genericArgs: Type list

    member this.Generics =
        match this with
        | Option gen | Array gen | List gen -> [gen]
        | FunctionType(LambdaType argType, returnType) -> [argType; returnType]
        | FunctionType(DelegateType argTypes, returnType) -> argTypes @ [returnType]
        | Tuple gen -> gen
        | ErasedUnion gen -> gen
        | DeclaredType(_,gen) -> gen
        | _ -> []
    member this.ReplaceGenerics(newGen: Type list) =
        match this with
        | Option _ -> Option newGen.Head
        | Array _  -> Array newGen.Head
        | List _   -> List newGen.Head
        | FunctionType(LambdaType _, _) ->
            let argTypes, returnType = List.splitLast newGen
            FunctionType(LambdaType argTypes.Head, returnType)
        | FunctionType(DelegateType _, _) ->
            let argTypes, returnType = List.splitLast newGen
            FunctionType(DelegateType argTypes, returnType)
        | Tuple _ -> Tuple newGen
        | ErasedUnion _ -> ErasedUnion newGen
        | DeclaredType(ent,_) -> DeclaredType(ent,newGen)
        | t -> t

type ValueDeclarationInfo =
    { Name: string
      IsPublic: bool
      IsMutable: bool
      IsEntryPoint: bool
      HasSpread: bool
      Range: SourceLocation option }

type ClassImplicitConstructorInfo =
    { Name: string
      Type: Type
      EntityName: string
      IsEntityPublic: bool
      IsConstructorPublic: bool
      HasSpread: bool
      Base: Type option
      Arguments: Ident list
      BoundConstructorThis: Ident }

type UnionConstructorInfo =
    { Type: Type
      EntityName: string
      IsPublic: bool }

type CompilerGeneratedConstructorInfo =
    { Type: Type
      EntityName: string
      IsPublic: bool }

type ConstructorKind =
    | ClassImplicitConstructor of ClassImplicitConstructorInfo
    | UnionConstructor of UnionConstructorInfo
    | CompilerGeneratedConstructor of CompilerGeneratedConstructorInfo

type AttachedMemberDeclarationInfo =
    { Name: string
      Kind: ObjectMemberKind
      EntityName: string }

type Declaration =
    | ActionDeclaration of Type
    | ValueDeclaration of Type * ValueDeclarationInfo
    | AttachedMemberDeclaration of args: Ident list * Type * AttachedMemberDeclarationInfo
    | ConstructorDeclaration of ConstructorKind * SourceLocation option

type IdentKind =
    | UserDeclared
    | CompilerGenerated
    | InlinedArg
    | BaseValueIdent
    | ThisArgIdentDeclaration

type Ident =
    { Name: string
      Type: Type
      Kind: IdentKind
      IsMutable: bool
      Range: SourceLocation option }
      member x.IsCompilerGenerated =
        match x.Kind with CompilerGenerated -> true | _ -> false
      member x.IsInlinedArg =
        match x.Kind with InlinedArg -> true | _ -> false
      member x.IsBaseValue =
        match x.Kind with BaseValueIdent -> true | _ -> false
      member x.IsThisArgDeclaration =
        match x.Kind with ThisArgIdentDeclaration -> true | _ -> false
      member x.DisplayName =
        x.Range
        |> Option.bind (fun r -> r.identifierName)
        |> Option.defaultValue x.Name

type ObjectMemberKind =
    | ObjectValue
    | ObjectMethod of hasSpread: bool
    | ObjectGetter
    | ObjectSetter
    | ObjectIterator