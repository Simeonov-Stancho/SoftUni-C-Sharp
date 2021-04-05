namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<List<ImportMovieDto>>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Movie> movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                TimeSpan duration;
                var isValidDuration = TimeSpan.TryParseExact(movieDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture, out duration);

                var isExist = movies.Any(m => m.Title == movieDto.Title);

                if (!IsValid(movieDto) || duration == null || isExist)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = Enum.Parse<Genre>(movieDto.Genre),
                    Duration = duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallSeatsDto = JsonConvert.DeserializeObject<List<ImportHallSeatDto>>(jsonString);

            StringBuilder sb = new StringBuilder();

            List<Hall> halls = new List<Hall>();

            foreach (var hallSeatDto in hallSeatsDto)
            {
                if (!IsValid(hallSeatDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallSeatDto.Name,
                    Is4Dx = hallSeatDto.Is4Dx,
                    Is3D = hallSeatDto.Is3D,
                };

                for (int i = 0; i < hallSeatDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat
                    {
                        Hall = hall,
                        HallId = hall.Id
                    });
                }

                string projType = "Normal";

                if (hall.Is3D && hall.Is4Dx)
                {
                    projType = "4Dx/3D";

                }

                else if (hall.Is4Dx)
                {
                    projType = "4Dx";
                }

                else if (hall.Is3D)
                {
                    projType = "3D";
                }

                halls.Add(hall);
                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, projType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlRoot = new XmlRootAttribute("Projections");

            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectionDto>), xmlRoot);

            var projectionsDto = (List<ImportProjectionDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var projections = new List<Projection>();
            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projectionsDto)
            {
                var hall = context.Halls.FirstOrDefault(h => h.Id == projectionDto.HallId);

                var movie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);

                DateTime dateTime;
                var isValidDate = DateTime.TryParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);


                if (!IsValid(projectionDto) || hall == null || movie == null || !isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    Movie = movie,
                    MovieId = projectionDto.MovieId,
                    Hall = hall,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, projection.Movie.Title, projection.DateTime.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlRoot = new XmlRootAttribute("Customers");

            var xmlSerializer = new XmlSerializer(typeof(List<ImportCustomerDto>), xmlRoot);

            var customersDto = (List<ImportCustomerDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var customers = new List<Customer>();
            StringBuilder sb = new StringBuilder();

            foreach (var customerDto in customersDto)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance
                };

                foreach (var ticketDto in customerDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var projection = context.Projections.FirstOrDefault(p => p.Id == ticketDto.ProjectionId);
                    if (projection == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        CustomerId = customer.Id,
                        Customer = customer,
                        ProjectionId = ticketDto.ProjectionId,
                        Projection = projection
                    };

                    customer.Tickets.Add(ticket);
                }

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}