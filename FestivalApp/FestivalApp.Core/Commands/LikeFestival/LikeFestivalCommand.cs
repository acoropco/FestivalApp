﻿using MediatR;

namespace FestivalApp.Core.Commands.LikeFestival
{
    public class LikeFestivalCommand : IRequest<Unit>
    {
        public int FestivalId { get; set; }

        public int UserId { get; set; }

        public LikeFestivalCommand(int festivalId, int userId)
        {
            FestivalId = festivalId;
            UserId = userId;
        }
    }
}
