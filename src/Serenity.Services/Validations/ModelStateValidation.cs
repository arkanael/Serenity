using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections;
using System.Linq;

namespace Serenity.Services.Validations
{
    public class ModelStateValidation
    {
        public static Hashtable GetErrors(ModelStateDictionary ModelState)
        {
            Hashtable resultado = new Hashtable();

            foreach (var state in ModelState)
            {
                if (state.Value.Errors.Count > 0)
                {
                    resultado[state.Key] = state.Value.Errors
                                            .Select(e => e.ErrorMessage)
                                            .ToList();
                }
            }

            return resultado;
        }
    }
}
