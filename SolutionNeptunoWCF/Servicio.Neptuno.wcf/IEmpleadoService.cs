using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Servicio.Neptuno.wcf
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEmpleadoService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEmpleadoService
    {
        [OperationContract]
        List<Empleado> EmpleadoListar();

        [OperationContract]
        void EmpleadoAdicionar(Empleado emp);

        [OperationContract]
        void EmpleadoActualizar(Empleado emp);

        [OperationContract]
        void EmpleadoEliminar(int emp);

        [OperationContract]
        Empleado EmpleadoBuscar(int emp);
    }
}
