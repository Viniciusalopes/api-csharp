using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaApi.Models
{
    public class Json
    {
        private string Type = "https://tools.ietf.org/html/rfc7231#section-";
        private string Section = "";
        private string Title = "One or more validation errors occurred.";
        private int Status = 400;
        private string[] Errors;
    }
}
