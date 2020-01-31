using System;
using System.ComponentModel.DataAnnotations;

namespace PessoaApi.CustomValidation
{
    public class DataNascimentoValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            this.setErrorMessage();
            DateTime dateTime = Convert.ToDateTime(value);

            // NOTA: A Classe DateTime já cuida da validação de meses, dias, bisexto, etc.

            if (dateTime > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        private void setErrorMessage()
        {
            this.ErrorMessage = "The field DataNascimento must be less than or equal to Today's Date";
        }
    }
}
