﻿namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Detalies { get; set; }
    }
}
