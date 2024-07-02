using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiPlayground.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest<string>
    {
        public long Id { get; set; }
    }
}
