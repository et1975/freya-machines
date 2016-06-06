﻿namespace Freya.Machines.Http

#nowarn "46"

open Arachne.Http
open Hephaestus

(* Post *)

[<RequireQualifiedAccess>]
module internal Post =

    (* Name *)

    [<Literal>]
    let Name =
        "http-post"

    (* Component *)

    let private post s =
        Method.specification Name (set [ POST ]) (
            s, Existence.specification Name (
                Responses.Moved.specification Name (
                    Responses.Missing.specification Name),
                Preconditions.Common.specification Name (
                    Preconditions.Unsafe.specification Name (
                        Conflict.specification Name (
                            Operations.specification Name POST (
                                Responses.Created.specification Name (
                                    Responses.Other.specification Name (
                                        Responses.Common.specification Name))))))))

    let component =
        { Metadata =
            { Name = Name
              Description = None }
          Requirements =
            { Required = set [ Core.Name ]
              Preconditions = List.empty }
          Operations =
            [ Splice (Key [ Core.Name; "fallback"; "fallback-decision" ], Right, post) ] }