using Microsoft.AspNetCore.Mvc;
using AtividadeMVC.Models;

namespace AtividadeMVC.Controllers
{
    public class EventoController : Controller
    {
        // Lista estática para persistir os dados em memória entre requisições
        private static List<Evento> _eventos = new List<Evento>
        {
            new Evento
            {
                Id = 1,
                Nome = "Workshop ASP.NET Core MVC",
                Descricao = "Aprenda na prática os fundamentos de arquitetura MVC com C#.",
                Local = "Auditório Principal - Tech Hub",
                DataEvento = DateTime.Now.AddDays(10),
                QuantidadeVagas = 50,
                ValorIngresso = 120.00m
            }
        };

        private static int _proximoId = 2; 

        public IActionResult Index()
        {
            return View(_eventos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(Evento evento)
        {
            if (!ModelState.IsValid)
            {
                return View(evento);
            }

            evento.Id = _proximoId++;
            _eventos.Add(evento);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            var viewModel = new BuscarEventoViewModel
            {
                Resultados = _eventos
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buscar(BuscarEventoViewModel model)
        {
            var consulta = _eventos.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(model.NomeBusca))
            {
                consulta = consulta.Where(e =>
                    e.Nome.Contains(model.NomeBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(model.LocalBusca))
            {
                consulta = consulta.Where(e =>
                    e.Local.Contains(model.LocalBusca, StringComparison.OrdinalIgnoreCase));
            }

            if (model.DataInicial.HasValue)
            {
                consulta = consulta.Where(e =>
                    e.DataEvento.Date >= model.DataInicial.Value.Date);
            }

            model.Resultados = consulta.ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhes(int id)
        {
            var evento = _eventos.FirstOrDefault(e => e.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }
    }
}