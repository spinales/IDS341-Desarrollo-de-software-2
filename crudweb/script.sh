#!/bin/bash

echo "working in file x...."

ls ./Models

echo "working with Ciudadanos..."
dotnet aspnet-codegenerator controller -name CiudadanoController -async -m Ciudadano -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Ciudadanos..."

echo "working with Ciudadanos Estado..."
dotnet aspnet-codegenerator controller -name CiudadanoEstadoController -async -m CiudadanoEstado -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Ciudadanos Estado..."

echo "working with Estado Civil..."
dotnet aspnet-codegenerator controller -name EstadoCivilController -async -m EstadoCivil -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Estado Civil..."

echo "working with Municipio..."
dotnet aspnet-codegenerator controller -name MunicipioController -async -m Municipio -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Municipio..."

echo "working with Nacionalidad..."
dotnet aspnet-codegenerator controller -name NacionalidadController -async -m Nacionalidad -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Nacionalidad..."

echo "working with Ocupacion..."
dotnet aspnet-codegenerator controller -name OcupacionController -async -m Ocupacion -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Ocupacion..."

echo "working with Provincia..."
dotnet aspnet-codegenerator controller -name ProvinciumController -async -m Provincium -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Provincia..."

echo "working with Sector..."
dotnet aspnet-codegenerator controller -name SectorController -async -m Sector -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Sector..."

echo "working with Tipo De Sangre..."
dotnet aspnet-codegenerator controller -name TipoDeSangreController -async -m TipoDeSangre -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Tipo De Sangre..."

echo "working with Usuario..."
dotnet aspnet-codegenerator controller -name UsuarioController -async -m Usuario -dc DSFEBABR2022Context -outDir Controllers
sleep 3
echo "Finish Usuario..."

echo "All controllers Finished...."
