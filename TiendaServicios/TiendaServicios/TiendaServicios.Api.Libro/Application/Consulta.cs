using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Application
{
    public class Consulta
    {
        public class Ejecuta : IRequest<List<LibroMaterialDTO>>
        {

        }
        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDTO>>
        {
            public readonly ContextoLibreria _context;
            public readonly IMapper _mapper;

            public Manejador(ContextoLibreria context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LibroMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var libros = await _context.LibreriaMaterial.ToListAsync();
                var librosDto = _mapper.Map < List<LibreriaMaterial>, List< LibroMaterialDTO >> (libros);
                return librosDto;
            }
        }
    }
}
