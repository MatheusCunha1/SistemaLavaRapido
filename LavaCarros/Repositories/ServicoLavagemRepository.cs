using System;
using System.Collections.Generic;
using LavaCarros.Data;
using System.Linq;

public class ServicoLavagemRepository
{
    private readonly CarroContext _context;

    public ServicoLavagemRepository(CarroContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AdicionarServicoLavagem(ServicoLavagem servicoLavagem)
    {
        if (_context != null)
        {
            _context.ServicosLavagem?.Add(servicoLavagem);
            _context.SaveChanges();
        }
    }

    public List<ServicoLavagem> ConsultarServicosLavagem()
    {
        return _context.ServicosLavagem?.ToList() ?? new List<ServicoLavagem>();
    }

    public ServicoLavagem? ObterDetalhesLavagem(string tipoLavagem)
    {
        return _context.ServicosLavagem
            ?.FirstOrDefault(s => s.Tipo == tipoLavagem);
    }

}
