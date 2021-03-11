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
    public class ConsultaFlitro
    {
        public class AutorUnico : IRequest<AutorDTO>
        {
            public AutorUnico(string guid)
            {
                Guid = guid;
            }

            public string Guid { get; set; }
        }

        public class Manejador : IRequestHandler<AutorUnico, AutorDTO>
        {
            public Manejador(ContextAutor context, IMapper mapper)
            {
                Context = context;
                _mapper = mapper;
            }

            public readonly ContextAutor Context;
            public readonly IMapper _mapper;

            public async Task<AutorDTO> Handle(AutorUnico request, CancellationToken cancellationToken)
            {
                var autor = await Context.AutorLibro.Where(x => x.AutorLibroGuid == request.Guid).FirstOrDefaultAsync();
                if (autor == null)
                    throw new Exception("El autor no existe");

                var autorDto = _mapper.Map<AutorLibro, AutorDTO>(autor);
                return autorDto;
            }
        }
    }
}
