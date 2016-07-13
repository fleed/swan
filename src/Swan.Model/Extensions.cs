namespace Swan.Model
{
    public static class Extensions
    {
        public static SwaggerDocument Convert(this Project project)
        {
            return new SwaggerDocument();
        }
    }
}