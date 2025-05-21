window.onload = function ()
{
    listar();
}

function listar()
{
    pintar({
        url: "Persona/ListarPersonas", 
        cabeceras: ["Nombre completo", "Fecha nacimiento", "Correo"],
        //Propiedades de PersonaCLS
        propiedades: ["nombrecompleto", "fechanacimientocadena", "correo"],
        propiedadID: "iidpersona",
        popup: true,
        titlePopup: "Persona",
        editar:true,
        eliminar:true
    },{
            url: "Persona/FiltrarPersonas",
            formulario: [
                [{
                    class: "col-md-6",
                    label: "Ingrese el nombre completo", 
                    type: "text",
                    name: "nombrecompleto"
                }
            ]]
    }, {
        type: "popup",
        urlrecuperar: "Persona/RecuperarPersona",
        parametrosRecuperar: "id",
        forumulario: [
            [
                {
                    class: "col-md-6 d-none",
                    label: "Id persona ",
                    type: "text",
                    name: "iidpersona",
                },
                {
                    class: "col-md-6",
                    label: "Nombre",
                    type: "text",
                    name: "nombrecompleto"
                },
                {
                    class: "col-md-6",
                    label: "Apellido paterno",
                    type: "text",
                    name: "appaterno"
                },
                {
                    class: "col-md-6",
                    label: "Apellido materno",
                    type: "text",
                    name: "apmaterno"

                },
                {
                    class: "col-md-6",
                    label: "Fecha nacimiento",
                    type: "date",
                    name: "fechanacimiento"
                },
                {
                    class: "col-md-6",
                    label: "Correo",
                    type: "text",
                    name: "correo"
                },
                {
                    class: "col-md-6",
                    label: "Sexo",
                    type: "redio",
                    labels: ["Masculino", "Femenino"],
                    values: ["2", "1"],
                    ids: ["rbMasculino", "rbFemenino"],
                    checked: "rbMasculino", 
                    name: "iisexo"
                }
            ]
        ]

        }
    )

}