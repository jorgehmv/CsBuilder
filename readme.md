CsBuilder
======================================================================

Domain Specific Language for C# code generation

CsBuilder is a strong example of the power that C# offers in creating Domain Specific Languages. It aims to generate C# code through a fluent interface that mimics real C# code.

A collection of classes modeling C# code is behind a facade of methods heavily relying in lambda expressions to achieve the feeling of coding.

	using(ICodeWriter codeWriter = new CodeWriter(new StreamWriter(File.Create("sum.cs"))))
	{
		Cs.Class("Sum", c =>
			{
				c.Method("DoSum", m =>
					{
						var a = Cs.Var("a");
						var b = Cs.Var("b");

						m.Return(a + b);
					}).OfType(CsType.Int).Param("a", CsType.Int)
										 .Param("b", CsType.Int);
			})

		.Render(codeWriter);
	}


While possibilities are huge this simple example will show enough to get you started experimenting.

Creating a Recursive Factorial Algorithm

    using (var codeWriter = new CodeWriter(new StreamWriter(fileStream)))
    {
        Cs.Class("RecursiveFactorialAlgorithm", c =>
        {
            c.Method("Solve", m =>
            {
                var n = Cs.Var("n");

                m.If(n <= 1, i =>
                {
                    i.Return(1);
                });

                m.Return(n * Cs.Call("Solve").Params(n - 1));
            }).OfType(CsType.Int).Param("n", CsType.Int);
        }).Implements("IAlgorithm")

        .Namespace("Algorithms")

        .Using("System")
        .Using("AlgorithmBuilder")

        .Render(codeWriter);
    }

Creating a Iterative Factorial Algorithm

    using (var codeWriter = new CodeWriter(new StreamWriter(fileStream)))
    {
        Cs.Class("IterativeFactorialAlgorithm", c =>
        {
            c.Method("Solve", m =>
            {
                var n = Cs.Var("n");
                var result = Cs.Var("result");

                m.If(n < 2, i =>
                {
                    i.Return(1);
                });

                m.Declare(result).OfType(CsType.Int);
                m.Assign(1).To(result);
                m.For(1).To(n).Do(f =>
                {
                    f.Assign(result * Cs.Var("i")).To(result);
                });

                m.Return(result);
            }).OfType(CsType.Int).Param("n", CsType.Int);
        }).Implements("IAlgorithm")

        .Namespace("Algorithms")

        .Using("System")
        .Using("AlgorithmBuilder")

        .Render(codeWriter);
    }

Below is the generated C# code of the previous blocks:

Recursive Factorial

	using @AlgorithmBuilder;
	using @System;
	namespace @Algorithms
	{
		public class @RecursiveFactorialAlgorithm : IAlgorithm
		{
			public virtual int @Solve(int @n)
			{
				if ((@n <= 1))
				{
					return 1;
				}

				return @n * Solve(@n - 1);
			}

		}

	}

Iterative Factorial

	using @AlgorithmBuilder;
	using @System;
	namespace @Algorithms
	{
		public class @IterativeFactorialAlgorithm : IAlgorithm
		{
			public virtual int @Solve(int @n)
			{
				if ((@n < 2))
				{
					return 1;
				}

				int @result;
				@result = 1;
				for (int @i = 1; (@i <= @n); @i++)
				{
					@result = @result * @i;
				}

				return @result;
			}

		}

	}
