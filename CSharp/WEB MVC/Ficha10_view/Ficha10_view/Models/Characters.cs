namespace FREQ_2019419
{
    public class Characters
    {
        public List<Character> CharactersList { get; set; }

        public Characters()
        {
            CharactersList = new List<Character>();
        }

        public Characters(List<Character> achar)
        {
            CharactersList = achar;
        }
    }
}
