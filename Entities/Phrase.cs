using System;


public class Phrase
{
    public int Id { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    int authorId { get; set; }

    public Category category { get; set; }

    public Author author { get; set; } 
    
}
