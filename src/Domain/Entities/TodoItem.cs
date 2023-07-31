﻿using CleanArchitecture.Domain.Share.Enums;

namespace CleanArchitecture.Domain.Entities;

public class TodoItem : BaseAuditableEntity<int>
{
    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public PriorityLevel Priority { get; set; }

    public DateTime? Reminder { get; set; }

    private bool _done;
    public bool Done
    {
        get => _done;
        set
        {
            if (value && !_done)
            {
                AddDomainEvent(new CompletedEvent<TodoItem>(this));
            }

            _done = value;
        }
    }

    public TodoList List { get; set; } = null!;
}
