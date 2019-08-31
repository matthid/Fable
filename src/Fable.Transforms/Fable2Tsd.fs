module Fable.Transforms.Fable2Tsd

open Fable
open Fable.Core
open Fable.AST

type Context =
  { File: Fable.File }

type ITsdCompiler =
    inherit ICompiler

module Util =
    let rec transformDeclarations (com: ITsdCompiler) ctx decls (transformed:TypeScript.Statement seq) =
        match decls with
        | [] -> transformed
        | decl::restDecls ->
            match decl with
            | Fable.ActionDeclaration e ->
                failwithf "Unknown  Fable.ActionDeclaration %A" decl
            | Fable.ValueDeclaration(value, info) ->
                failwithf "Unknown Fable.ValueDeclaration %A" decl
            | Fable.ConstructorDeclaration(kind, r) ->
                failwithf "Unknown Fable.ConstructorDeclaration %A" decl
            | Fable.AttachedMemberDeclaration(args, body, info) ->
                failwithf "Unknown Fable.AttachedMemberDeclaration %A" decl


module Compiler =
    open Util

    type TsdCompiler (com: ICompiler) =

        interface ITsdCompiler
        interface ICompiler with
            member __.Options = com.Options
            member __.LibraryDir = com.LibraryDir
            member __.CurrentFile = com.CurrentFile
            member __.GetUniqueVar(name) = com.GetUniqueVar(?name=name)
            member __.GetRootModule(fileName) = com.GetRootModule(fileName)
            member __.GetOrAddInlineExpr(fullName, generate) = com.GetOrAddInlineExpr(fullName, generate)
            member __.AddLog(msg, severity, ?range, ?fileName:string, ?tag: string) =
                com.AddLog(msg, severity, ?range=range, ?fileName=fileName, ?tag=tag)

    let makeCompiler com = new TsdCompiler(com)

    let transformFile (com: ICompiler) (file: Fable.File)  : TypeScript.Statement seq =
        try
            // let t = PerfTimer("Fable > Babel")
            let com = makeCompiler com :> ITsdCompiler
            let ctx =
              { File = file }
            let rootDecls = transformDeclarations com ctx file.Declarations []
            //let importDecls = com.GetAllImports() |> transformImports
            rootDecls
        with
        | ex -> exn (sprintf "%s (%s)" ex.Message file.SourcePath, ex) |> raise
