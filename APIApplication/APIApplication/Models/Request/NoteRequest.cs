﻿namespace APIApplication.Models.Request
{
    public class NoteRequest
    {
        public required string Title { get; set; } = string.Empty;
        public required string Content { get; set; } = string.Empty;
    }
}
