using System;
using Xunit;

namespace AlgorithmsConsole.Test
{
    public class TreeHashTest
    {
        [Fact]
        public void TreeHashSize()
        {
            var ex = Assert.Throws<Exception>(() => {
                TreeHash treeHash = new TreeHash(4);
            });

            Assert.Equal("The tree hash must have more than 4 lines", ex.Message);
        }

        [Fact]
        public void TreeHashResult()
        {
            TreeHash treeHash = new TreeHash(5);
            Assert.IsType<string>(treeHash.treeResult);
        }
    }
}
