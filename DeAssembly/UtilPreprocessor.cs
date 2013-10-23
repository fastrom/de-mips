/////////////////////////////////////////////////////////////////////////
//                                                                     //
//    DeMIPS - A MIPS decompiler                                       //
//                                                                     //
//        Copyright (c) 2008 by Ruben Acuna and Michael Bradley        //
//                                                                     //
// This file is part of DeMIPS.                                        //
//                                                                     //
// DeMIPS is free software; you can redistribute it and/or             //
// modify it under the terms of the GNU Lesser General Public          //
// License as published by the Free Software Foundation; either        //
// version 3 of the License, or (at your option) any later version.    //
//                                                                     //
// This library is distributed in the hope that it will be useful,     //
// but WITHOUT ANY WARRANTY; without even the implied warranty of      //
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the       //
// GNU Lesser General Public License for more details.                 //
//                                                                     //
// You should have received a copy of the GNU Lesser General Public    //
// License along with this library; if not, write to the Free Software //
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA           //
// 02111-1307, USA, or contact the author(s):                          //
//                                                                     //
// Ruben Acuna <flyingfowlsoftware@earthlink.net>                      //
//                                                                     //
/////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;

namespace DeMIPS
{
    class UtilPreprocessor
    {
        /// <summary>
        /// Splits a lines into code and comment portions.
        /// </summary>
        /// <param name="code">Code to process.</param>
        /// <param name="commentMarker">Character(s) that mark regions of comments.</param>
        static public void PreprocessComments(string[] code, string commentMarker)
        {
            for(int i = 0; i < code.Length; i++)
            {
                if (code[i].Contains(commentMarker))
                    code[i] = code[i].Substring(0, code[i].IndexOf(commentMarker)).Trim();
            }
        }

        /// <summary>
        /// Reconstructs each line to include only one space between tokens.
        /// </summary>
        /// <param name="code">Code to process.</param>
        static public void PreprocessWhiteSpace(string[] code)
        {
            for(int i = 0; i < code.Length; i++)
            {
                string[] lineTokens = code[i].Split(' ');
                string processedLine = "";
                
                foreach (string token in lineTokens)
                    if (!token.Trim().Equals(""))
                        processedLine += token + " ";

                code[i] = processedLine.Trim(); //HACK: the above line always leaves a trailing space.
            }
        }
    }
}
