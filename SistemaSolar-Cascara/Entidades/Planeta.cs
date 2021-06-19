using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void InformacionDeAvance(object sender, PlanetaEventArgs e);
    public class Planeta
    {
        private short velocidadTraslacion;
        private short posicionActual;
        private short radioRespectoSol;
        private object objetoAsociado;
        //firma evento -> modificador de visibilidad, tipo de delegado, nombre del evento
        public event InformacionDeAvance InformarAvance; //los eventos son de un tipo de delegado, siempre hay que especificar el tipo de delegaod.

        public Planeta(short velocidad, short posicion, short radioRespectoSol, object objetoVisual)
        {
            this.VelocidadTraslacion = velocidad;
            this.PosicionActual = posicion;
            this.ObjetoAsociado1 = objetoVisual;
            this.RadioRespectoSol = radioRespectoSol;
        }

        /// <summary>
        /// PictureBox u objeto gráfico asociado al planeta.
        /// </summary>
        [System.Xml.Serialization.XmlIgnore]
        public object ObjetoAsociado
        {
            get
            {
                return this.ObjetoAsociado1;
            }
            set
            {
                this.ObjetoAsociado1 = value;
            }
        }

        public short VelocidadTraslacion { get => velocidadTraslacion; set => velocidadTraslacion = value; }
        public short PosicionActual { get => posicionActual; set => posicionActual = value; }
        public short RadioRespectoSol { get => radioRespectoSol; set => radioRespectoSol = value; }
        public object ObjetoAsociado1 { get => objetoAsociado; set => objetoAsociado = value; }


        /// <summary>
        /// Avance del planeta según su velocidad
        /// </summary>
        public short Avanzar()
        {
            this.PosicionActual += VelocidadTraslacion;
            return this.PosicionActual;
        }

        /// <summary>
        /// Simulación del movimiento del planeta
        /// </summary>
        public void AnimarSistemaSolar()
        {
            do
            {
                System.Threading.Thread.Sleep(60 + this.VelocidadTraslacion);
                //Invoke dispara el evento y cualquier manejador que este asociado va a capturar la info del evento y van a hace rlo que quieran en base a eso.
                InformarAvance.Invoke(this, new PlanetaEventArgs(this.Avanzar(), this.RadioRespectoSol));
            } while (true);
        }
    }
}
