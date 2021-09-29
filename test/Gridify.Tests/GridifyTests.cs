using Gridify.Exceptions;
using Gridify.Filter;
using Gridify.Order;
using Gridify.Page;
using Sample.Entity;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Gridify.Tests
{
    public class GridifyTests
    {
        private readonly IQueryable<Student> _students;

        public GridifyTests()
        {
            _students = DataInitializer.GenerateStudentList();
        }

        [Fact]
        public void Gridify_Should_Success_Returns_Filtered_When_Passed_Multiple_Filter()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new[]
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Midterm),
                                Value = "98"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.StartsWith,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.Name),
                                Value = "Moha"
                            }
                        }
                    }
                },

                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                },

                // Page
                Pagination = new Pagination
                {
                    PageSize = 100,
                    PageNumber = 1
                }
            };

            // Act
            var result = _students.Gridify(request);

            var values = (IEnumerable<Student>)result.Value;

            // Assert
            Assert.True(values.Any(x => x.Name == "Mohammad Sadeq"));
        }

        [Fact]
        public void Gridify_Should_Success_Returns_Filtered_When_Passed_Multiple_Filter_With_Decimal_Double_Types()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.Decimal,
                                Key = nameof(Student) + "." + nameof(Student.Bonus),
                                Value = "50.5m"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessOrEqualThan,
                                DataType = DataType.Double,
                                Key = nameof(Student) + "." + nameof(Student.Average),
                                Value = "75.5"
                            }
                        }
                    }
                },

                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                },

                // Page
                Pagination = new Pagination
                {
                    PageSize = 100,
                    PageNumber = 1
                }
            };

            var expectedCount = _students.Count(x => x.Bonus > 50.5m && x.Average <= 75.5);

            // Act
            var result = _students.Gridify(request);

            var values = (IEnumerable<Student>)result.Value;

            // Assert
            Assert.True(values.Any(x => x.Name == "Mohammad Sadeq"));
            Assert.True(expectedCount == values.Count());
        }

        [Fact]
        public void Gridify_Should_Success_Returns_Filtered_When_Passed_Multiple_FilterList_With_DateTime_Filter()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.DateTime,
                                Key = nameof(Student) + "." + nameof(Student.Birthday),
                                Value = "1993-06-07 00:00:00"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessThan,
                                DataType = DataType.DateTime,
                                Key = nameof(Student) + "." + nameof(Student.Birthday),
                                Value = "1997-06-07 00:00:00"
                            }
                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var result = _students.Gridify(request);

            var values = (IEnumerable<Student>)result.Value;

            // Assert
            Assert.True(values.Any(x => x.Name == "Mohammad Sadeq"));
        }

        [Fact]
        public void Gridify_Should_Success_Returns_Filtered_When_Passed_Multiple_FilterList_With_Char_Filter()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.Equal,
                                DataType = DataType.Char,
                                Key = nameof(Student) + "." + nameof(Student.Level),
                                Value = "a"
                            }
                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var result = _students.Gridify(request);

            var values = (IEnumerable<Student>)result.Value;

            // Assert
            Assert.True(values.Any(x => x.Name == "Mohammad Sadeq"));
        }

        [Fact]
        public void Gridify_Should_Success_Returns_Filtered_When_Passed_Multiple_FilterList_With_Multiple_Filter()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Final),
                                Value = "9"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessOrEqualThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Midterm),
                                Value = "100"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.StartsWith,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.Surname),
                                Value = "A"
                            }
                        }
                    },
                    new FilterList
                    {
                        Logic = FilterLogic.Or,
                        Filters =  new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.Equal,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.IdentityNumber),
                                Value = "100010"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.Equal,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.IdentityNumber),
                                Value = "100101"
                            },

                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var result = _students.Gridify(request);

            var values = (IEnumerable<Student>)result.Value;

            // Assert
            Assert.True(values.Any(x => x.Name == "Mohammad Sadeq"));
        }

        [Fact]
        public void Gridify_Should_Fail_Returns_IntDataTypeNotSupportedException()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.Contains,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Midterm),
                                Value = "9"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Final),
                                Value = "91"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.StartsWith,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.Name),
                                Value = "Author"
                            }
                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var ex = Record.Exception(() => _students.Gridify(request));

            // Assert
            Assert.True(ex is IntDataTypeNotSupportedException);
        }

        [Fact]
        public void Gridify_Should_Fail_Returns_StringDataTypeNotSupportedException()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Logic = FilterLogic.And,
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Midterm),
                                Value = "9"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Final),
                                Value = "91"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.Name),
                                Value = "A"
                            }
                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var ex = Record.Exception(() => _students.Gridify(request));

            // Assert
            Assert.True(ex is StringDataTypeNotSupportedException);
        }

        [Fact]
        public void Gridify_Should_Fail_Returns_LogicOperatorNotFoundException()
        {
            // Arrange
            var request = new GridRequest
            {
                // Filter
                Filters = new[]
                {
                    new FilterList
                    {
                        Filters = new []
                        {
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Midterm),
                                Value = "9"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.LessThan,
                                DataType = DataType.Int,
                                Key = nameof(Student) + "." + nameof(Student.Final),
                                Value = "91"
                            },
                            new Filter.Filter
                            {
                                Operator = Operators.GreaterThan,
                                DataType = DataType.String,
                                Key = nameof(Student) + "." + nameof(Student.Name),
                                Value = "A"
                            }
                        }
                    }
                },


                // Order
                Orders = new[]
                {
                    new Order.Order
                    {
                        Direction = OrderDirection.Desc,
                        OrderBy = nameof(Student.IdentityNumber)
                    }
                }
            };

            // Act
            var ex = Record.Exception(() => _students.Gridify(request));

            // Assert
            Assert.True(ex is StringDataTypeNotSupportedException);
        }
    }
}

