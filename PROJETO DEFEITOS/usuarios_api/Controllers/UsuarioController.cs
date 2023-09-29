using usuarios_api.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace usuarios_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]    
    public class UsuarioController : Controller
    {
        private readonly string BancoDeDados = "DadosUsuarios.txt";
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        private List<Usuario> CarregarUsuarios()
        {
            if (!System.IO.File.Exists(BancoDeDados))
            {
                return new List<Usuario>();
            }

            var lines = System.IO.File.ReadAllBytes(BancoDeDados);

            return lines.Select(line =>
            {
                var parts = line.Split('!');

                return new Usuario
                {
                    Id = int.Parse(parts[0]),
                    NomeCompleto = parts[1],
                    ImagemUsuario = parts[2],
                    NomeUsuario = parts[3],
                    Senha = parts[4],
                    IsAtivo = bool.Parse(parts[5])
                };
            }).ToList();
        }

        [HttpGet]
        public IActionResult GetAllUsuarios()
        {
            var listaUsuarios = CarregarUsuarios();
            return Ok(listaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUsuarioId(string id)
        {
            var listaUsuarios = CarregarUsuarios();
            var usuario = listaUsuarios.FirstOrDefault(t => t.Id == id);

            if (usuario  == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario(Usuario usuario)
        {
            var listaUsuarios = CarregarUsuarios();
            usuario.Id = listaUsuarios.Count() > 0 ? listaUsuarios.First().Id + 1 : 1;

            listaUsuarios.Add(usuario);

            SalvarUsuario(listaUsuarios);

            return CreatedAtAction(nameof(GetUsuarioId), new { id = usuario.Id }, usuario);            
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(Usuario usuario)
        {
            var listaUsuarios = CarregarUsuarios();
            var existeUsuario = listaUsuarios.FirstOrDefault(t => t.Id == usuario.Id);
            
            if (existeUsuario == null)
            {
                return NotFound();
            }

            existeUsuario.NomeCompleto = usuario.NomeCompleto;
            existeUsuario.ImagemUsuario = usuario.ImagemUsuario;
            existeUsuario.NomeUsuario = usuario.NomeCompleto;
            existeUsuario.Senha = usuario.Senha;
            existeUsuario.IsAtivo = usuario.IsAtivo;

            SalvarUsuario(listaUsuarios);

            return Ok (usuario);
        }

        [HttpPut("AtivaDesativa/{id}")]
        public IActionResult AtivaDesativa(int id)
        {
            var listaUsuarios = CarregarUsuarios();
            var existeUsuario = listaUsuarios.FirstOrDefault(t => t.Id == id);
            
            if (existeUsuario == null)
            {
                return NotFound();
            }

            existeUsuario.IsAtivo = !existeUsuario.IsAtivo; //Inverte o valor de ativo e desativo

            SalvarUsuario(listaUsuarios);

            return Ok (existeUsuario);
        }

        private void SalvarUsuario(List<Usuario> listaUsuarios)
        {
            var linha = listaUsuarios.Select(t => $"{t.Id}|{t.NomeCompleto}|{t.ImagemUsuario}|{t.NomeUsuario}|{t.Senha}|{t.IsAtivo}");
            System.IO.File.WriteAllLines(BancoDeDados, linha);
        }
    }
}