using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaApi.CustomValidation
{
    public class UfValidation : ValidationAttribute
    {
        private readonly string[] UFs = new string[27] {
            "AC", "AL", "AP", "AM", "BA",
            "CE", "DF", "ES", "GO", "MA",
            "MT", "MS", "MG", "PA", "PB",
            "PR", "PE", "PI", "RJ", "RN",
            "RS", "RO", "RR", "SC", "SP",
            "SE", "TO"
        };

        public override bool IsValid(object value)
        {
            string uf = Convert.ToString(value);
            setErrorMessage();
            return UFs.Contains(uf);
        }

        private void setErrorMessage()
        {
            string preUfs = "The field Uf is invalid. Valid values: -> [";
            string posUfs = "] <- (In capital letters)";
            this.ErrorMessage = preUfs + this.getUfs() + posUfs;
        }

        private string getUfs()
        {
            string ret = "";
            foreach (string u in UFs)
            {
                ret += u + ", ";
            }
            return ret[0..^2];
        }
    }
}
