using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShopProduct.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into products(name, price, description, stock, imageurl, categoryid) values" +
                "('caderno', 7.55, 'caderno', 10, 'caderno1.jpg', 1)");

            mb.Sql("insert into products(name, price, description, stock, imageurl, categoryid) values" +
                "('lapis', 3.45, 'lapis preto', 20, 'lapis.jpg', 1)");

            mb.Sql("insert into products(name, price, description, stock, imageurl, categoryid) values" +
                "('clips', 5.33, 'clips para papel', 50, 'clips.jpg', 2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from products");
        }
    }
}
