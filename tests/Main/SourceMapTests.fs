module Fable.Tests.SourceMaps

open Util.Testing
open Fable.MyImport
open Node
open Fable.Core
open Fable.Core.JsInterop
open Fable.Core.JS

let buildDir = __SOURCE_DIRECTORY__ + "/../../build/tests/SourceMaps/"
let sourceDir = __SOURCE_DIRECTORY__ + "/../SourceMaps/"


let readFile (f:string) : string =
    fs.readFileSync(f, "utf8")


type TestSourceMap =
    { FileName : string
      OriginalSource : string
      OriginalFile : string
      GeneratedSource : string
      GeneratedFile : string
      SourceMapText : string
      SourceMapFile : string
      RawSourceMap : SourceMap.RawSourceMap
      }

let readTestFiles (fileName:string) =
    let jsName = fileName.Replace(".fs", ".js")
    let mapName = jsName + ".map"
    let generatedFile = buildDir + jsName
    let generatedSource = readFile (generatedFile)
    let originalFile = sourceDir + fileName
    let originalSource = readFile (originalFile)
    let sourceMapFile = buildDir + mapName
    let sourceMapText = readFile (sourceMapFile)
    let map : SourceMap.RawSourceMap = JSON.parse(sourceMapText) :?> _
    
    { FileName = fileName
      OriginalSource = originalSource; OriginalFile = originalFile
      GeneratedSource = generatedSource; GeneratedFile = generatedFile
      SourceMapText = sourceMapText; SourceMapFile = sourceMapFile
      RawSourceMap = map }

let readSourceMap (t:TestSourceMap) =
    promise {
          t.RawSourceMap.file <- t.FileName
          let! sm = SourceMap.sourceMap.SourceMapConsumer.Create(t.RawSourceMap)
          
          //let html = generateHtml.Invoke(sm, generatedSource, ResizeArray [originalSource])
          return sm

    }
let tests =
  testList "Source Map Tests" [
    testCaseAsync "Simple Range" <| fun () ->
      async {

        let t = readTestFiles "simple-range.fs"
        let! sm = readSourceMap t |> Async.AwaitPromise
        console.log("sourceMap", sm)
        //SourceMap.sou
        //let sm = SourceMap.sourceMap.SourceMapConsumer.Create(map)
        
        ignore sm


      }
  ]
