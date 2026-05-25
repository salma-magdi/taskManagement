using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.generalResponse
{
   public class generalApiResponse<T>
    {
       
            public bool Success { get; set; }
            public string Message { get; set; }
            public T? Data { get; set; }
            public List<string>? Errors { get; set; }

            public static generalApiResponse<T> SuccessResult(T data, string message = "")
            {
                return new generalApiResponse<T>
                {
                    Success = true,
                    Data = data,
                    Message = message
                };
            }

            public static generalApiResponse<T> Fail(string message, List<string>? errors = null)
            {
                return new generalApiResponse<T>
                {
                    Success = false,
                    Message = message,
                    Errors = errors
                };
            }
        }
}
