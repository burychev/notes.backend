using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Notes.Domain;


namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Note>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Details { get; set; }
        public string Title { get; set; }
       

    }
}
