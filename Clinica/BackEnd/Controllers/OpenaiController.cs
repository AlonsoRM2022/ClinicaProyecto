using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenAI_API;
using OpenAI_API.Completions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenaiController : ControllerBase
    {
        private readonly string _apiKey;

        public OpenaiController(IConfiguration configuration)
        {
            _apiKey = configuration["OpenAI:ApiKey"];
        }

        public class JsonRequestModel
        {
            public string Query { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] JsonRequestModel requestData)
        {
            string query = requestData.Query;

            string prompt = "Dado el diagnóstico '" + query + "', ¿puedes proporcionar recomendaciones generales de salud, consejos de estilo de vida o sugerencias de tratamientos que podrían ser beneficiosos para mejorar la calidad de vida y gestionar los síntomas asociados? Por favor, ten en cuenta que estoy buscando información general y que siempre consultaré con un profesional de la salud para obtener asesoramiento personalizado. Responde únicamente con un parrafo en prosa corto de los consejos, sin responder con una lista o dar detalles o explicaciones adicionales.";

            string outputResult = "";
            var openai = new OpenAIAPI(_apiKey);
            CompletionRequest completionRequest = new CompletionRequest();
            completionRequest.Prompt = prompt;
            completionRequest.Model = OpenAI_API.Models.Model.DavinciText;
            completionRequest.MaxTokens = 500;

            var completions = await openai.Completions.CreateCompletionAsync(completionRequest);

            foreach (var completion in completions.Completions)
            {
                outputResult += completion.Text;
            }

            return Ok(outputResult);
        }
    }
}

