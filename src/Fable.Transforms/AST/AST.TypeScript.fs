// See node_modules\typescript\lib\typescript.d.ts
// See https://github.com/Microsoft/TypeScript/wiki/Using-the-Compiler-API#creating-and-printing-a-typescript-ast
// See https://ts-ast-viewer.com/
namespace Fable.AST.TypeScript

open Fable.Core

type [<RequireQualifiedAccess>] SyntaxKind =
    | Unknown = 0
    | EndOfFileToken = 1
    | SingleLineCommentTrivia = 2
    | MultiLineCommentTrivia = 3
    | NewLineTrivia = 4
    | WhitespaceTrivia = 5
    | ShebangTrivia = 6
    | ConflictMarkerTrivia = 7
    | NumericLiteral = 8
    | BigIntLiteral = 9
    | StringLiteral = 10
    | JsxText = 11
    | JsxTextAllWhiteSpaces = 12
    | RegularExpressionLiteral = 13
    | NoSubstitutionTemplateLiteral = 14
    | TemplateHead = 15
    | TemplateMiddle = 16
    | TemplateTail = 17
    | OpenBraceToken = 18
    | CloseBraceToken = 19
    | OpenParenToken = 20
    | CloseParenToken = 21
    | OpenBracketToken = 22
    | CloseBracketToken = 23
    | DotToken = 24
    | DotDotDotToken = 25
    | SemicolonToken = 26
    | CommaToken = 27
    | LessThanToken = 28
    | LessThanSlashToken = 29
    | GreaterThanToken = 30
    | LessThanEqualsToken = 31
    | GreaterThanEqualsToken = 32
    | EqualsEqualsToken = 33
    | ExclamationEqualsToken = 34
    | EqualsEqualsEqualsToken = 35
    | ExclamationEqualsEqualsToken = 36
    | EqualsGreaterThanToken = 37
    | PlusToken = 38
    | MinusToken = 39
    | AsteriskToken = 40
    | AsteriskAsteriskToken = 41
    | SlashToken = 42
    | PercentToken = 43
    | PlusPlusToken = 44
    | MinusMinusToken = 45
    | LessThanLessThanToken = 46
    | GreaterThanGreaterThanToken = 47
    | GreaterThanGreaterThanGreaterThanToken = 48
    | AmpersandToken = 49
    | BarToken = 50
    | CaretToken = 51
    | ExclamationToken = 52
    | TildeToken = 53
    | AmpersandAmpersandToken = 54
    | BarBarToken = 55
    | QuestionToken = 56
    | ColonToken = 57
    | AtToken = 58
    | EqualsToken = 59
    | PlusEqualsToken = 60
    | MinusEqualsToken = 61
    | AsteriskEqualsToken = 62
    | AsteriskAsteriskEqualsToken = 63
    | SlashEqualsToken = 64
    | PercentEqualsToken = 65
    | LessThanLessThanEqualsToken = 66
    | GreaterThanGreaterThanEqualsToken = 67
    | GreaterThanGreaterThanGreaterThanEqualsToken = 68
    | AmpersandEqualsToken = 69
    | BarEqualsToken = 70
    | CaretEqualsToken = 71
    | Identifier = 72
    | BreakKeyword = 73
    | CaseKeyword = 74
    | CatchKeyword = 75
    | ClassKeyword = 76
    | ConstKeyword = 77
    | ContinueKeyword = 78
    | DebuggerKeyword = 79
    | DefaultKeyword = 80
    | DeleteKeyword = 81
    | DoKeyword = 82
    | ElseKeyword = 83
    | EnumKeyword = 84
    | ExportKeyword = 85
    | ExtendsKeyword = 86
    | FalseKeyword = 87
    | FinallyKeyword = 88
    | ForKeyword = 89
    | FunctionKeyword = 90
    | IfKeyword = 91
    | ImportKeyword = 92
    | InKeyword = 93
    | InstanceOfKeyword = 94
    | NewKeyword = 95
    | NullKeyword = 96
    | ReturnKeyword = 97
    | SuperKeyword = 98
    | SwitchKeyword = 99
    | ThisKeyword = 100
    | ThrowKeyword = 101
    | TrueKeyword = 102
    | TryKeyword = 103
    | TypeOfKeyword = 104
    | VarKeyword = 105
    | VoidKeyword = 106
    | WhileKeyword = 107
    | WithKeyword = 108
    | ImplementsKeyword = 109
    | InterfaceKeyword = 110
    | LetKeyword = 111
    | PackageKeyword = 112
    | PrivateKeyword = 113
    | ProtectedKeyword = 114
    | PublicKeyword = 115
    | StaticKeyword = 116
    | YieldKeyword = 117
    | AbstractKeyword = 118
    | AsKeyword = 119
    | AnyKeyword = 120
    | AsyncKeyword = 121
    | AwaitKeyword = 122
    | BooleanKeyword = 123
    | ConstructorKeyword = 124
    | DeclareKeyword = 125
    | GetKeyword = 126
    | InferKeyword = 127
    | IsKeyword = 128
    | KeyOfKeyword = 129
    | ModuleKeyword = 130
    | NamespaceKeyword = 131
    | NeverKeyword = 132
    | ReadonlyKeyword = 133
    | RequireKeyword = 134
    | NumberKeyword = 135
    | ObjectKeyword = 136
    | SetKeyword = 137
    | StringKeyword = 138
    | SymbolKeyword = 139
    | TypeKeyword = 140
    | UndefinedKeyword = 141
    | UniqueKeyword = 142
    | UnknownKeyword = 143
    | FromKeyword = 144
    | GlobalKeyword = 145
    | BigIntKeyword = 146
    | OfKeyword = 147
    | QualifiedName = 148
    | ComputedPropertyName = 149
    | TypeParameter = 150
    | Parameter = 151
    | Decorator = 152
    | PropertySignature = 153
    | PropertyDeclaration = 154
    | MethodSignature = 155
    | MethodDeclaration = 156
    | Constructor = 157
    | GetAccessor = 158
    | SetAccessor = 159
    | CallSignature = 160
    | ConstructSignature = 161
    | IndexSignature = 162
    | TypePredicate = 163
    | TypeReference = 164
    | FunctionType = 165
    | ConstructorType = 166
    | TypeQuery = 167
    | TypeLiteral = 168
    | ArrayType = 169
    | TupleType = 170
    | OptionalType = 171
    | RestType = 172
    | UnionType = 173
    | IntersectionType = 174
    | ConditionalType = 175
    | InferType = 176
    | ParenthesizedType = 177
    | ThisType = 178
    | TypeOperator = 179
    | IndexedAccessType = 180
    | MappedType = 181
    | LiteralType = 182
    | ImportType = 183
    | ObjectBindingPattern = 184
    | ArrayBindingPattern = 185
    | BindingElement = 186
    | ArrayLiteralExpression = 187
    | ObjectLiteralExpression = 188
    | PropertyAccessExpression = 189
    | ElementAccessExpression = 190
    | CallExpression = 191
    | NewExpression = 192
    | TaggedTemplateExpression = 193
    | TypeAssertionExpression = 194
    | ParenthesizedExpression = 195
    | FunctionExpression = 196
    | ArrowFunction = 197
    | DeleteExpression = 198
    | TypeOfExpression = 199
    | VoidExpression = 200
    | AwaitExpression = 201
    | PrefixUnaryExpression = 202
    | PostfixUnaryExpression = 203
    | BinaryExpression = 204
    | ConditionalExpression = 205
    | TemplateExpression = 206
    | YieldExpression = 207
    | SpreadElement = 208
    | ClassExpression = 209
    | OmittedExpression = 210
    | ExpressionWithTypeArguments = 211
    | AsExpression = 212
    | NonNullExpression = 213
    | MetaProperty = 214
    | SyntheticExpression = 215
    | TemplateSpan = 216
    | SemicolonClassElement = 217
    | Block = 218
    | VariableStatement = 219
    | EmptyStatement = 220
    | ExpressionStatement = 221
    | IfStatement = 222
    | DoStatement = 223
    | WhileStatement = 224
    | ForStatement = 225
    | ForInStatement = 226
    | ForOfStatement = 227
    | ContinueStatement = 228
    | BreakStatement = 229
    | ReturnStatement = 230
    | WithStatement = 231
    | SwitchStatement = 232
    | LabeledStatement = 233
    | ThrowStatement = 234
    | TryStatement = 235
    | DebuggerStatement = 236
    | VariableDeclaration = 237
    | VariableDeclarationList = 238
    | FunctionDeclaration = 239
    | ClassDeclaration = 240
    | InterfaceDeclaration = 241
    | TypeAliasDeclaration = 242
    | EnumDeclaration = 243
    | ModuleDeclaration = 244
    | ModuleBlock = 245
    | CaseBlock = 246
    | NamespaceExportDeclaration = 247
    | ImportEqualsDeclaration = 248
    | ImportDeclaration = 249
    | ImportClause = 250
    | NamespaceImport = 251
    | NamedImports = 252
    | ImportSpecifier = 253
    | ExportAssignment = 254
    | ExportDeclaration = 255
    | NamedExports = 256
    | ExportSpecifier = 257
    | MissingDeclaration = 258
    | ExternalModuleReference = 259
    | JsxElement = 260
    | JsxSelfClosingElement = 261
    | JsxOpeningElement = 262
    | JsxClosingElement = 263
    | JsxFragment = 264
    | JsxOpeningFragment = 265
    | JsxClosingFragment = 266
    | JsxAttribute = 267
    | JsxAttributes = 268
    | JsxSpreadAttribute = 269
    | JsxExpression = 270
    | CaseClause = 271
    | DefaultClause = 272
    | HeritageClause = 273
    | CatchClause = 274
    | PropertyAssignment = 275
    | ShorthandPropertyAssignment = 276
    | SpreadAssignment = 277
    | EnumMember = 278
    | UnparsedPrologue = 279
    | UnparsedPrepend = 280
    | UnparsedText = 281
    | UnparsedInternalText = 282
    | UnparsedSyntheticReference = 283
    | SourceFile = 284
    | Bundle = 285
    | UnparsedSource = 286
    | InputFiles = 287
    | JSDocTypeExpression = 288
    | JSDocAllType = 289
    | JSDocUnknownType = 290
    | JSDocNullableType = 291
    | JSDocNonNullableType = 292
    | JSDocOptionalType = 293
    | JSDocFunctionType = 294
    | JSDocVariadicType = 295
    | JSDocComment = 296
    | JSDocTypeLiteral = 297
    | JSDocSignature = 298
    | JSDocTag = 299
    | JSDocAugmentsTag = 300
    | JSDocClassTag = 301
    | JSDocCallbackTag = 302
    | JSDocEnumTag = 303
    | JSDocParameterTag = 304
    | JSDocReturnTag = 305
    | JSDocThisTag = 306
    | JSDocTypeTag = 307
    | JSDocTemplateTag = 308
    | JSDocTypedefTag = 309
    | JSDocPropertyTag = 310
    | SyntaxList = 311
    | NotEmittedStatement = 312
    | PartiallyEmittedExpression = 313
    | CommaListExpression = 314
    | MergeDeclarationMarker = 315
    | EndOfDeclarationMarker = 316
    | Count = 317
    | FirstAssignment = 59
    | LastAssignment = 71
    | FirstCompoundAssignment = 60
    | LastCompoundAssignment = 71
    | FirstReservedWord = 73
    | LastReservedWord = 108
    | FirstKeyword = 73
    | LastKeyword = 147
    | FirstFutureReservedWord = 109
    | LastFutureReservedWord = 117
    | FirstTypeNode = 163
    | LastTypeNode = 183
    | FirstPunctuation = 18
    | LastPunctuation = 71
    | FirstToken = 0
    | LastToken = 147
    | FirstTriviaToken = 2
    | LastTriviaToken = 7
    | FirstLiteralToken = 8
    | LastLiteralToken = 14
    | FirstTemplateToken = 14
    | LastTemplateToken = 17
    | FirstBinaryOperator = 28
    | LastBinaryOperator = 71
    | FirstNode = 148
    | FirstJSDocNode = 288
    | LastJSDocNode = 310
    | FirstJSDocTagNode = 299
    | LastJSDocTagNode = 310

type [<RequireQualifiedAccess>] ScriptTarget =
    | ES3 = 0
    | ES5 = 1
    | ES2015 = 2
    | ES2016 = 3
    | ES2017 = 4
    | ES2018 = 5
    | ES2019 = 6
    | ESNext = 7
    | JSON = 100
    | Latest = 7

type [<RequireQualifiedAccess>] ScriptKind =
    | Unknown = 0
    | JS = 1
    | JSX = 2
    | TS = 3
    | TSX = 4
    | External = 5
    | JSON = 6
    | Deferred = 7
 
type ReadonlyArray<'a> = ResizeArray<'a>
type JSDocContainer = interface end
type Node = interface end

type Token =
    inherit Node
type Modifier = Token // At least a subset
type QuestionToken = Token // At least a subset
type DotDotDotToken = Token // At least a subset

type Decorator =
    inherit Node
type Declaration =
    inherit Node
type NamedDeclaration =
    inherit Declaration
type TypeParameterDeclaration =
    inherit NamedDeclaration
type TypeElement =
    inherit NamedDeclaration
type HeritageClause =
    inherit Node
type Expression =
    inherit Node
type Statement =
    inherit Node
type TypeNode =
    inherit Node
type KeywordTypeNode =
    inherit TypeNode
type DeclarationStatement =
    inherit NamedDeclaration
    inherit Statement
type ExportAssignment =
    inherit DeclarationStatement
type ParameterDeclaration =
    inherit JSDocContainer
    inherit NamedDeclaration
type InterfaceDeclaration =
    inherit JSDocContainer
    inherit DeclarationStatement
type SignatureDeclarationBase =
    inherit JSDocContainer
    inherit NamedDeclaration
type MethodSignature =
    inherit SignatureDeclarationBase
    inherit TypeElement

type BindingName =
    inherit Node
type Identifier =
    inherit Expression
    inherit Declaration
type SourceFile =
    inherit Declaration
type PropertyName = interface end // type PropertyName = Identifier | StringLiteral | NumericLiteral | ComputedPropertyName;

type PrinterOptions = interface end
type PrintHandlers = interface end


type [<RequireQualifiedAccess>] EmitHint =
    | SourceFile = 0
    | Expression = 1
    | IdentifierName = 2
    | MappedTypeParameter = 3
    | Unspecified = 4
    | EmbeddedStatement = 5

type [<RequireQualifiedAccess>] ListFormat =
    | None = 0
    | SingleLine = 0
    | MultiLine = 1
    | PreserveLines = 2
    | LinesMask = 3
    | NotDelimited = 0
    | BarDelimited = 4
    | AmpersandDelimited = 8
    | CommaDelimited = 16
    | AsteriskDelimited = 32
    | DelimitersMask = 60
    | AllowTrailingComma = 64
    | Indented = 128
    | SpaceBetweenBraces = 256
    | SpaceBetweenSiblings = 512
    | Braces = 1024
    | Parenthesis = 2048
    | AngleBrackets = 4096
    | SquareBrackets = 8192
    | BracketsMask = 15360
    | OptionalIfUndefined = 16384
    | OptionalIfEmpty = 32768
    | Optional = 49152
    | PreferNewLine = 65536
    | NoTrailingNewLine = 131072
    | NoInterveningComments = 262144
    | NoSpaceIfEmpty = 524288
    | SingleElement = 1048576
    | Modifiers = 262656
    | HeritageClauses = 512
    | SingleLineTypeLiteralMembers = 768
    | MultiLineTypeLiteralMembers = 32897
    | TupleTypeElements = 528
    | UnionTypeConstituents = 516
    | IntersectionTypeConstituents = 520
    | ObjectBindingPatternElements = 525136
    | ArrayBindingPatternElements = 524880
    | ObjectLiteralExpressionProperties = 526226
    | ArrayLiteralExpressionElements = 8914
    | CommaListElements = 528
    | CallExpressionArguments = 2576
    | NewExpressionArguments = 18960
    | TemplateExpressionSpans = 262144
    | SingleLineBlockStatements = 768
    | MultiLineBlockStatements = 129
    | VariableDeclarationList = 528
    | SingleLineFunctionBodyStatements = 768
    | MultiLineFunctionBodyStatements = 1
    | ClassHeritageClauses = 0
    | ClassMembers = 129
    | InterfaceMembers = 129
    | EnumMembers = 145
    | CaseBlockClauses = 129
    | NamedImportsOrExportsElements = 525136
    | JsxElementOrFragmentChildren = 262144
    | JsxElementAttributes = 262656
    | CaseOrDefaultClauseStatements = 163969
    | HeritageClauseTypes = 528
    | SourceFileStatements = 131073
    | Decorators = 49153
    | TypeArguments = 53776
    | TypeParameters = 53776
    | Parameters = 2576
    | IndexSignatureParameters = 8848
    | JSDocComment = 33

type [<AllowNullLiteral>] Printer =
    /// <summary>Print a node and its subtree as-is, without any emit transformations.</summary>
    /// <param name="hint">A value indicating the purpose of a node. This is primarily used to
    /// distinguish between an `Identifier` used in an expression position, versus an
    /// `Identifier` used as an `IdentifierName` as part of a declaration. For most nodes you
    /// should just pass `Unspecified`.</param>
    /// <param name="node">The node to print. The node and its subtree are printed as-is, without any
    /// emit transformations.</param>
    /// <param name="sourceFile">A source file that provides context for the node. The source text of
    /// the file is used to emit the original source content for literals and identifiers, while
    /// the identifiers of the source file are used when generating unique names to avoid
    /// collisions.</param>
    abstract printNode: hint: EmitHint * node: Node * sourceFile: SourceFile -> string
    /// Prints a list of nodes using the given format flags
    abstract printList: format: ListFormat * list: ResizeArray<'T> * sourceFile: SourceFile -> string
    /// Prints a source file as-is, without any emit transformations.
    abstract printFile: sourceFile: SourceFile -> string
    /// Prints a bundle of source files as-is, without any emit transformations.
    //abstract printBundle: bundle: Bundle -> string

type ITSNamespace =

    abstract createKeywordTypeNode : kind: SyntaxKind -> KeywordTypeNode
    abstract createIdentifier : text: string -> Identifier
    abstract createInterfaceDeclaration :
        decorators: ReadonlyArray<Decorator> option *
        modifiers: ReadonlyArray<Modifier> option *
        name: U2<string, Identifier> *
        typeParameters: ReadonlyArray<TypeParameterDeclaration> option *
        heritageClauses: ReadonlyArray<HeritageClause> option *
        members: ReadonlyArray<TypeElement> -> InterfaceDeclaration
    abstract createParameter : 
        decorators: ReadonlyArray<Decorator> option *
        modifiers: ReadonlyArray<Modifier> option *
        dotDotDotToken: DotDotDotToken option *
        name: U2<string, BindingName> *
        // optional
        questionToken: QuestionToken option *
        ``type``: TypeNode option *
        initializer: Expression option -> ParameterDeclaration
    abstract createMethodSignature : 
        typeParameters: ReadonlyArray<TypeParameterDeclaration> option *
        parameters: ReadonlyArray<ParameterDeclaration> *
        ``type``: TypeNode option *
        name: U2<string, PropertyName> *
        questionToken: QuestionToken option -> MethodSignature

    abstract createExportAssignment :
        decorators: ReadonlyArray<Decorator> option *
        modifiers: ReadonlyArray<Modifier> option *
        isExportEquals: bool option *
        expression: Expression -> ExportAssignment


    // Printing
    abstract createSourceFile :
        fileName: string *
        sourceText: string *
        languageVersion: ScriptTarget *
        // optional
        setParentNodes: bool option *
        scriptKind: ScriptKind option -> SourceFile
    abstract createPrinter :
        // optional
        printerOptions: PrinterOptions option *
        handlers: PrintHandlers option -> Printer    