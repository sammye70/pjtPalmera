
CREATE PROCEDURE sp_add_clientes
(
IN _cedula VARCHAR(11),
IN _nombre VARCHAR(45),
IN _apellidos VARCHAR(45), 
IN _telefonos VARCHAR(45),
IN _direccion VARCHAR(45),
IN _ciudad VARCHAR(45),
IN _limitecredito DECIMAL(5,0),
IN _createby INT(11),
IN _created DATE
)

BEGIN
INSERT INTO ebgsolut_abejas.clientes(cedula,nombre,apellidos,telefonos,direccion,ciudad, limitecredito,createby,created) VALUES(_cedula,_nombre,_apellidos,_telefonos,_direccion,_ciudad,_limitecredito,_createby,_created);
END 
