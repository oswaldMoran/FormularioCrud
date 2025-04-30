select * from USUARIO

create proc sp_User
as
begin
	select idUsuario,Nombres,Apellidos,correo,Activo From USUARIO
end
exec sp_User