using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace PessoaApi.CustomJsonResult
{
    public static class ConflictJsonResult
    {
        public static JsonResult JsonDuplicatedCpf(string cpf)
        {
            return new JsonResult(new
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Title = "One or more validation errors occurred.",
                Status = 409,
                TraceId = ActivityTraceId.CreateRandom().ToString(),
                Errors = new { Cpf = new[] { "There is already a person with this Cpf. (" + cpf + ")" } }
            }
            );
        }
    }
}
