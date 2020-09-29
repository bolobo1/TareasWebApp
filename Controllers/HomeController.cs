using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TareasWebApp.Models;
using TareasWebApp.Models.ColaboradorModels;


namespace TareasWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string EndPoint = "https://localhost:44353/";
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (HttpClient HttpClient = new HttpClient())
                {
                    Uri URL = new UriBuilder(EndPoint + "api/Crud").Uri;
                    using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URL).ConfigureAwait(true))
                    {
                        string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                        List<SPTareasListarCLS> ListadoTareas = JsonConvert.DeserializeObject<List<SPTareasListarCLS>>(ContenidoRespuestaAPI);
                        return View(ListadoTareas);
                    }
                }
            }catch(Exception error)
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int TAREAS_ID)
        {

            using (HttpClient HttpClient = new HttpClient())
            {

                Uri URLC = new UriBuilder(EndPoint + "api/Colaboradores").Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URLC).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    List<SPColaboradorListarCLS> ListaColaboradores = JsonConvert.DeserializeObject<List<SPColaboradorListarCLS>>(ContenidoRespuestaAPI);
                    ViewBag.ListaColaboradores = ListaColaboradores;
                }
            }
            using (HttpClient HttpClient = new HttpClient())
            {

                Uri URLC = new UriBuilder(EndPoint + "api/Colaboradores").Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URLC).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    List<SPColaboradorListarCLS> ListaColaboradores = JsonConvert.DeserializeObject<List<SPColaboradorListarCLS>>(ContenidoRespuestaAPI);
                    ViewBag.ListaColaboradores = ListaColaboradores;
                }

                Uri URLT = new UriBuilder(EndPoint + "api/Crud/" + TAREAS_ID).Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URLT).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    SPTareaListarIdCLS ListaTareas = JsonConvert.DeserializeObject<SPTareaListarIdCLS>(ContenidoRespuestaAPI);
                    return View(ListaTareas);
                }

            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                using (HttpClient HttpClient = new HttpClient())
                {
                    Uri URL = new UriBuilder(EndPoint + "api/Colaboradores").Uri;
                    using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URL).ConfigureAwait(true))
                    {
                        string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                        List<SPColaboradorListarCLS> ListaColaboradores = JsonConvert.DeserializeObject<List<SPColaboradorListarCLS>>(ContenidoRespuestaAPI);
                        ViewBag.ListaColaboradores = ListaColaboradores;
                    }
                }
                return View();
            }
            catch (Exception error) { return View(); }
        }
        [HttpPost]
        public async Task<IActionResult> Create(SPTareaCreateCLS Modelo)
        {
            if (Modelo is null) throw new ArgumentNullException(paramName: nameof(Modelo));

            using (HttpClient HttpClient = new HttpClient())
            {
                using (HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Modelo), Encoding.UTF8, "application/json"))
                {
                    Uri URL = new UriBuilder(EndPoint + "api/Crud").Uri;
                    using (HttpResponseMessage RespuestaAPI = await HttpClient.PostAsync(URL, ContentModel).ConfigureAwait(true))
                    {
                        if (RespuestaAPI.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return View();
                        }
                    }
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int TAREAS_ID)
        {

            using (HttpClient HttpClient = new HttpClient())
            {

                Uri URLC = new UriBuilder(EndPoint + "api/Colaboradores").Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URLC).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    List<SPColaboradorListarCLS> ListaColaboradores = JsonConvert.DeserializeObject<List<SPColaboradorListarCLS>>(ContenidoRespuestaAPI);
                    ViewBag.ListaColaboradores = ListaColaboradores;
                }
            }
            using (HttpClient HttpClient = new HttpClient())
            {
                Uri URL = new UriBuilder(EndPoint + "api/Crud/" + TAREAS_ID).Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URL).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    SPTareaListarIdCLS ListaTareas = JsonConvert.DeserializeObject<SPTareaListarIdCLS>(ContenidoRespuestaAPI);
                    return View(ListaTareas);
                }
            }
        }

        [HttpGet]
        public async Task<int> ValidarEdit(int TAREAS_ID)
        {
            using (HttpClient HttpClient = new HttpClient())
            {
                Uri URL = new UriBuilder(EndPoint + "api/Crud/" + TAREAS_ID).Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URL).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    SPTareaListarIdCLS ListaTareas = JsonConvert.DeserializeObject<SPTareaListarIdCLS>(ContenidoRespuestaAPI);

                    var estado = ListaTareas.TAREAS_ESTADO;
                    var result = 1;

                    if (estado == "FINALIZADA")
                    {
                        result = 0;
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SPTareaListarIdCLS Modelo)
        {

            int Response = await this.ValidarEdit(Modelo.TAREAS_ID);
            
            if (Response != 0)
            {
                if (Modelo is null) throw new ArgumentNullException(paramName: nameof(Modelo));

                using (HttpClient HttpClient = new HttpClient())
                {
                    using (HttpContent ContentModel = new StringContent(JsonConvert.SerializeObject(Modelo), Encoding.UTF8, "application/json"))
                    {
                        Uri URL = new UriBuilder(EndPoint + "api/Crud/" + Modelo.TAREAS_ID).Uri;
                        using (HttpResponseMessage RespuestaAPI = await HttpClient.PutAsync(URL, ContentModel).ConfigureAwait(true))
                        {
                            if (RespuestaAPI.IsSuccessStatusCode)
                            {
                                return RedirectToAction("Index");
                            }
                            else
                            {
                                var Response2 = await this.Edit(Modelo.TAREAS_ID);
                                ViewBag.validation = Response;
                                return View();
                            }
                        }
                    }
                }
            }
            else 
            {
                var Response2 = await this.Edit(Modelo.TAREAS_ID);
                ViewBag.validation = Response;
                return View();
            }


        }



        [HttpGet]
        public async Task<int> ValidarProceso(int TAREAS_ID)
        {
            using (HttpClient HttpClient = new HttpClient())
            {
                Uri URL = new UriBuilder(EndPoint + "api/Crud/" + TAREAS_ID).Uri;
                using (HttpResponseMessage RespuestaAPI = await HttpClient.GetAsync(URL).ConfigureAwait(true))
                {
                    string ContenidoRespuestaAPI = await RespuestaAPI.Content.ReadAsStringAsync().ConfigureAwait(true);
                    SPTareaListarIdCLS ListaTareas = JsonConvert.DeserializeObject<SPTareaListarIdCLS>(ContenidoRespuestaAPI);

                    var estado = ListaTareas.TAREAS_ESTADO;
                    var result = 1;

                    if (estado == "EN PROCESO")
                    {
                        result = 0;
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int TAREAS_ID)
        {

            int Response = await this.ValidarProceso(TAREAS_ID);

            if (Response != 0) 
            {
                using (HttpClient HttpClient = new HttpClient())
                {
                    Uri URL = new UriBuilder(EndPoint + "api/Crud/" + TAREAS_ID).Uri;
                    using (HttpResponseMessage RespuestaAPI = await HttpClient.DeleteAsync(URL).ConfigureAwait(true))
                    {
                        if (RespuestaAPI.IsSuccessStatusCode)
                        {
                            var Response2 = await this.Index();
                            ViewBag.validation = Response;
                            return View("Index");
                        }
                        else
                        {
                            var Response2 = await this.Index();
                            ViewBag.validation = Response;
                            return View("Index");
                        }
                    }
                }
            }
            else
            {
                var Response2 = await this.Index();
                ViewBag.validation = Response;
                return View("Index");
            }

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
