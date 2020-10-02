namespace UFN_CG
{
    public class MeshFilter
    {
        Mesh mesh;

        public Mesh Mesh{ get => mesh; set=> mesh = value; }

        #region Constructors

        public MeshFilter() => Mesh = null;

        public MeshFilter(Mesh mesh) => this.mesh = mesh;

        public MeshFilter(string pathTo_3D_Object) 
        {
            // Abre arquivo e extrai as informaçoes de vertices e triangulos.
            // Monta uma nova Mesh com todos os vertices e triangulos
        }

        #endregion

        #region Read and create a new mesh 

        // Not implemented yet

        #endregion
    }
}
