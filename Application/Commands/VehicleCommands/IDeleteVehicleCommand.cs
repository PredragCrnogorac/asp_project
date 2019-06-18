using Application.Intefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.VehicleCommands
{
	public interface IDeleteVehicleCommand : ICommand<int>
	{
	}
}
