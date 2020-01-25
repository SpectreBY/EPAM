using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Task3EnumsLib.Enums;

namespace Task3FiguresLib.Interfaces
{
    interface IWriteFile
    {
        /// <summary>
        /// Method for save figure to xml file by XML Writer
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="filename"></param>
        void SaveFiguresByXmlWriter(SaveModes mode, string filename);

        /// <summary>
        /// Method for save figure to xml file by Stream Writer
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="filename"></param>
        void SaveFiguresByStreamWriter(SaveModes mode, string filename);

        /// <summary>
        /// Method for read data of figure by XML Reader
        /// </summary>
        /// <param name="filename"></param>
        void ReadFiguresByXmlReader(string filename);

        /// <summary>
        /// Method for read data of figure by Stream Reader
        /// </summary>
        /// <param name="filename"></param>
        void ReadFiguresByStreamReader(string filename);
    }
}
