using Test.Model;

namespace Test.Service
{
    public static class Tree
    {
        public static Node root = null;

        public static Node FindNode(Node root, string value)
        {
            if (root == null)
                return null;

            if (root.Value.Equals(value))
                return root;

            foreach (var child in root.Children)
            {
                var result = FindNode(child, value);
                if (result != null)
                    return result;
            }

            return null;
        }

        public static Node Create(string path)
        {
            root = new Node(0, "root", null);

            //string path = "/Users/eugene/Documents/app/note1.txt";
            string ggg = "Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik";


            string parent = null;

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    var adv = line.Split(':');
                    if (adv.Length == 2)
                    {
                        string[] locations = adv[1].Split(",");

                        foreach (string location in locations)
                        {
                            var loc = location.Split("/");
                            if (loc.Length > 0)
                            {

                                for (int i = 0; i < loc.Length; i++)
                                {
                                    if (i == 0)
                                    {
                                        parent = loc[i];
                                        if (FindNode(root, loc[i]) == null)
                                        {
                                            root.Children.Add(new Node(1, loc[i], root));
                                        }

                                    }
                                    else
                                    {
                                        parent = loc[i-1];
                                        var node = FindNode(root, loc[i]);
                                        if (node == null)
                                        {
                                            node = FindNode(root, parent);
                                            node.Children.Add(new Node(node.Level +1, loc[i], node));
                                        }

                                        if (i + 1 == loc.Length)
                                        {
                                            parent = loc[i];
                                            node = FindNode(root, parent);
                                            node.Children.Add(new Node(node.Level + 1, adv[0], node));
                                        }
                                    }

                                }

                            }
                        }
                    }
                }
            }
            return root;
        }
    }
}
