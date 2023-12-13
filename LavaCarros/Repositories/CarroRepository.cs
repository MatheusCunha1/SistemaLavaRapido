using System.Collections.Generic;
using System.Linq;
using LavaCarros.Data;

namespace LavaCarros.Repositories
{
    public class CarroRepository
    {
        private readonly CarroContext _context;

        public CarroRepository(CarroContext context)
        {
            _context = context;
        }

        public void AdicionarCarro(Carro carro)
        {
            if (_context != null)
            {
                _context.Carros?.Add(carro);
                _context.SaveChanges();
            }
        }

        public List<Carro> ConsultarCarros()
        {
            var carros = _context.Carros?.ToList() ?? new List<Carro>();
            return carros;
        }

        public void RemoverCarro(int carroId)
        {
            if (_context.Carros != null)
            {
                var carro = _context.Carros.FirstOrDefault(c => c.Id == carroId);

                if (carro != null)
                {
                    _context.Carros.Remove(carro);
                    _context.SaveChanges();
                }
            }
        }

    }
}
