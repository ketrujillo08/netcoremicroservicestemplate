using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicio.API.Author.Model;
using TiendaServicio.API.Author.Persistence;

namespace TiendaServicio.API.Author.Application
{
    public class Consulta
    {
        public class ListaAutor : IRequest<List<AutorDTO>>
        {}

        public class Manejador : IRequestHandler<ListaAutor,List<AutorDTO>>
        {
            private readonly ContextAutor _context;
            private readonly IMapper _mapper;
            public Manejador(ContextAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            async Task<List<AutorDTO>> IRequestHandler<ListaAutor, List<AutorDTO>>.Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                var result = await _context.AutorLibro.ToListAsync();
                var autoresdto = _mapper.Map<List<AutorLibro>, List<AutorDTO>>(result);
                return autoresdto;
                
            }
        }
    }
}
