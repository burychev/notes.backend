﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Notes.Domain;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesDbContext _dbContext;

        public UpdateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNoteCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            { 
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Detalis = request.Details;
            entity.Title = request.Title; 
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
