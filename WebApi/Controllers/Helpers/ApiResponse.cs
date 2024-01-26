using Application.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Helpers;

public static class ApiResponse
{
    public static ObjectResult GetObjectResult(Response response)
    {
        return response.Succeeded
            ? new ObjectResult(response)
                { StatusCode = 200, ContentTypes = { "application/json" } }
            : new ObjectResult(response.Error)
                { StatusCode = response.Error.ErrorStatusCode, ContentTypes = { "application/json" } };
    }
}