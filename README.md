Aplicación Web app esqueleto para tener una base que permita crear una Web Api echa en Net 7.0 Core, implementando la nueva arquitectura dominio

---------------------------------------------
--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 --
+++++++++++++++++++++++++++++++++++++++++++++
**CRUD para todas las tablas se realizo**
**El numero de peticiones son de 8 por 10s**
**Se esta manejando versionado de 1.0 y 1.1**
**la duracion del token es de 1 min**
**Paginacion son los siguientes EnbPoint, con versionado de 1.1 y Autenticacion para aquellos que tengan el toquen**
1. Cita
http://localhost:5000/api/Cita/Paginacion

2. DetalleMovimiento 
http://localhost:5000/api/DetalleMovimiento/Paginacion

3. Especie 
http://localhost:5000/api/Especie/Paginacion

4. Laboratorio
http://localhost:5000/api/Laboratorio/Paginacion

5. Mascotas
http://localhost:5000/api/Mascota/Paginacion

6. Medicamento
http://localhost:5000/api/Medicamento/Paginacion

7. MedicamentoProveedor
http://localhost:5000/api/MedicamentoProveedor/Paginacion

8. Propietario
http://localhost:5000/api/Propietario/Paginacion

9. Proveedor
http://localhost:5000/api/Proveedor/Paginacion

10. Raza
http://localhost:5000/api/Raza/Paginacion

11. Rol 
http://localhost:5000/api/Rol/Paginacion

12. TipoMovimiento
http://localhost:5000/api/TipoMovimiento/Paginacion

13. TratamientoMedico
http://localhost:5000/api/TratamientoMedico/Paginacion

14. Usuario
http://localhost:5000/api/Usuario/Paginacion

15. UsuariosRoles
http://localhost:5000/api/UsuariosRoles/Pagina

16. Veterinario 
http://localhost:5000/api/Veterinario/Paginacion

17. MovimientoMedicamento
http://localhost:5000/api/MovimientoMedicamento/Paginacion

**Las consulats estan en dos controladores que son ConsultasGrupoAController y ConsultasGrupoBController**
**los Endpoint de las consultas no tiene autorizacion o autenticacion y no cuentan con versionado**

**CONSULTAS GRUPO A**

1. Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano
    vascular.
2. Listar los medicamentos que pertenezcan a el laboratorio Genfar
3. Mostrar las mascotas que se encuentren registradas cuya especie sea felina.
4. Listar los propietarios y sus mascotas.
5. Listar los medicamentos que tenga un precio de venta mayor a 50000
6. Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre
    del 2023

**CONSULTAS GRUPO B**

1. Listar todas las mascotas agrupadas por especie.
2. Listar todos los movimientos de medicamentos y el valor total de cada movimiento.
3. Listar las mascotas que fueron atendidas por un determinado veterinario.
4. Listar los proveedores que me venden un determinado medicamento.
5. Listar las mascotas y sus propietarios cuya raza sea Golden Retriver
6. Listar la cantidad de mascotas que pertenecen a una raza a una raza. **Nota:** Se debe mostrar
    una lista de las razas y la cantidad de mascotas que pertenecen a la raza.
    

TODAS LAS CONSULTAS DE LOS **GRUPO A** Y **GRUPO B** FUERON TERMINADAS 