using Microsoft.Bot.Builder.AI.QnA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchoBot1.Services
{
    public interface IQnAMakerServices
    {

        QnAMaker QnAMaker { get; }
    }
}
