﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PessoaApi.CustomJsonResult
{
    public static class SuccessJsonResult
    {
        public static JsonResult JsonExcluded(object pessoa)
        {
            return new JsonResult(new
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.3.1",
                Title = "Successfully deleted.",
                Status = 200,
                TraceId = ActivityTraceId.CreateRandom().ToString(),
                Excluded = new { Person = new[] { pessoa } }
            }
           );
        }
    }
}
