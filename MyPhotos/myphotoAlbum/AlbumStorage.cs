using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Manning.myphotoAlbum
{
    public class AlbumStorageException : Exception
    {
        public AlbumStorageException() : base() { }
        public AlbumStorageException(string msg) : base(msg) { }
        public AlbumStorageException(string msg, Exception inner) : base(msg, inner) { }
    }

     public class AlbumStorage
    {
        static private int CurentVersion = 63;
        static private void WriteAlbum(PhotoAlbum album, string path)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(path, false);
                sw.WriteLine(CurentVersion.ToString());
                foreach (photograph p in album)
                    WritePhoto(sw, p);
                album.HasChanged = false;

            }
            catch (UnauthorizedAccessException uax)
            {
                throw new AlbumStorageException("Unable to access album" + path, uax);

            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
        static private void WritePhoto(StreamWriter sw, photograph p)
        {
            sw.WriteLine(p.FileName);
            sw.WriteLine(p.Caption != null ? p.Caption : "");
            sw.WriteLine(p.DateTaken.ToString());
            sw.WriteLine(p.Photographer != null ? p.Photographer : "");
            sw.WriteLine(p.Notes != null ? p.Notes : "");
        }
        static public PhotoAlbum ReadAlbum(string path)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(path);
                string version = sr.ReadLine();
                PhotoAlbum album = new PhotoAlbum();
                switch (version)
                {
                    case "63":
                        ReadAlbumV63(sr, album);
                        break;
                    default:
                        throw new AlbumStorageException("unrecognized album version");
                }
                album.HasChanged = false;
                return album;
            }
            catch (FileNotFoundException fnx)
            {
                throw new AlbumStorageException("Unable to read album" + path, fnx);
            }
            finally
            {
                if (sr != null)
                    sr.Close();
            }
        }
        static private void ReadAlbumV63 (StreamReader sr,PhotoAlbum album)
        {
            photograph p;
            do
            {
                p = ReadPhotoV63(sr);
                if (p != null)
                    album.Add(p);

            }
            while (p != null);
            
        }
        static private photograph ReadPhotoV63(StreamReader sr)
        {
            string file = sr.ReadLine();
            if (file == null || file.Length == 0)
                return null;
            photograph p = new photograph(file);
            p.Caption = sr.ReadLine();
            p.DateTaken = DateTime.Parse(sr.ReadLine());
            p.Photographer = sr.ReadLine();
            p.Notes = sr.ReadLine();
            return p;
        }
     }

}
    

