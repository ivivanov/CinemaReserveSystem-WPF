using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using WpfExam.Models;
using CinemaReserve.ResponseModels;

namespace WpfExam.Data
{
    public class DataPersister
    {

        private const string BaseServicesUrl = "http://localhost:50971/api/";

        internal static IEnumerable<CinemaModel> GetCinemas()
        {
            var respone = HttpRequester.Get<IEnumerable<CinemaModel>>(BaseServicesUrl + "cinemas");
            return respone;
        }

        internal static IEnumerable<MovieModel> GetMoviesByCinemaId(int id)
        {
            var respone = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "cinemas/" + id);
            return respone;
        }

        internal static IEnumerable<ProjectionModel> GetMovieProjections(int cinemaId, int movieId)
        {
            var respone = HttpRequester.Get<IEnumerable<ProjectionModel>>(BaseServicesUrl + "cinemas/" + cinemaId + "/projections/" + movieId);
            return respone;
        }

        internal static IEnumerable<MovieModel> GetAllMovies()
        {
            var respone = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "movies");
            return respone;
        }

        internal static MovieDetailsModel GetMovieDetails(int p)
        {
            var respone = HttpRequester.Get<MovieDetailsModel>(BaseServicesUrl + "movies/" + p);
            return respone;
        }

        //internal static string LoginUser(string username, string password)
        //{
        //    string authCode = CalculateSHA1(password, Encoding.Default);

        //    var userModel = new LoginRequestModel()
        //    {
        //        Username = username,
        //        AuthCode = authCode
        //    };

        //    var loginResponse = HttpRequester.Post<LoginResponseModel>(BaseServicesUrl + "users/login",
        //        userModel);

        //    SessionKey = loginResponse.SessionKey;
        //    CurrentUser = loginResponse.Nickname;

        //    return loginResponse.Nickname;
        //}



        //public static IEnumerable<ArticleViewModel> GetArticles()
        //{
        //    IEnumerable<ArticleModel> articleModels =
        //        HttpRequester.Get<IEnumerable<ArticleModel>>(BaseServicesUrl + "Articles/get/" + SessionKey);

        //    IEnumerable<ArticleViewModel> articles =
        //        from article in articleModels
        //        select new ArticleViewModel()
        //        {
        //            Id = article.Id,
        //            Author = article.Author,
        //            PostedDate = article.PostedDate.ToShortDateString() + " " + article.PostedDate.ToShortTimeString(),
        //            Rating = article.Rating,
        //            Title = article.Title,
        //            IsResolved = article.IsResolved
        //        };

        //    return articles;
        //}

        //public static IEnumerable<ArticleViewModel> GetArticlesByTagId(int tagId)
        //{
        //    IEnumerable<ArticleModel> articleModels = HttpRequester.Get<IEnumerable<ArticleModel>>(BaseServicesUrl +
        //        "Articles/getByTag/" + SessionKey + "?id=" + tagId);

        //    IEnumerable<ArticleViewModel> articles =
        //     from articleModel in articleModels
        //     select new ArticleViewModel()
        //     {
        //         Id = articleModel.Id,
        //         Author = articleModel.Author,
        //         PostedDate = articleModel.PostedDate.ToShortDateString() + " " + articleModel.PostedDate.ToShortTimeString(),
        //         Rating = articleModel.Rating,
        //         Title = articleModel.Title,
        //         IsResolved = articleModel.IsResolved
        //     };

        //    return articles;
        //}

        //public static IEnumerable<ArticleViewModel> GetArticlesByUser()
        //{
        //    IEnumerable<ArticleModel> articleModels = HttpRequester.Get<IEnumerable<ArticleModel>>(BaseServicesUrl +
        //            "Users/Articles/" + SessionKey);

        //    IEnumerable<ArticleViewModel> articles =
        //     from articleModel in articleModels
        //     select new ArticleViewModel()
        //     {
        //         Id = articleModel.Id,
        //         Author = articleModel.Author,
        //         PostedDate = articleModel.PostedDate.ToShortDateString() + " " + articleModel.PostedDate.ToShortTimeString(),
        //         Rating = articleModel.Rating,
        //         Title = articleModel.Title,
        //         IsResolved = articleModel.IsResolved
        //     };

        //    return articles;
        //}

        //public static string AddArticle(string title, bool isResolved, string addNotes, string issue, string solution)
        //{
        //    ArticleFullModel newArticle = new ArticleFullModel()
        //    {
        //        Title = title,
        //        Author = CurrentUser,
        //        Rating = 0,
        //        PostedDate = DateTime.Now,
        //        Issue = issue,
        //        Solution = solution,
        //        IsResolved = isResolved,
        //        AdditionalNotes = addNotes,
        //    };

        //    var regResponse = HttpRequester.Post<ArticleResponseModel>(BaseServicesUrl + "articles/add/" + SessionKey,
        //        newArticle);

        //    return regResponse.Title;
        //}

        //public static ArticleViewModel GetArticleById(int id)
        //{
        //    ArticleFullModel articleModel = HttpRequester.Get<ArticleFullModel>(BaseServicesUrl + "Articles/get/" +
        //        SessionKey + "?id=" + id);

        //    ArticleViewModel article = new ArticleViewModel()
        //    {
        //        Id = articleModel.Id,
        //        Author = articleModel.Author,
        //        PostedDate = articleModel.PostedDate.ToShortDateString() + " " + articleModel.PostedDate.ToShortTimeString(),
        //        Rating = articleModel.Rating,
        //        Title = articleModel.Title,
        //        IsResolved = articleModel.IsResolved,
        //        AdditionalNotes = articleModel.AdditionalNotes,
        //        Issue = articleModel.Issue,
        //        Solution = articleModel.Solution,
        //        Comments = articleModel.Comments,
        //        Tags = articleModel.Tags
        //    };

        //    return article;
        //}

        //internal static bool LogoutUser()
        //{
        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;
        //    var isLogoutSuccessful = HttpRequester.Put(BaseServicesUrl + "users/logout", headers);
        //    return isLogoutSuccessful;
        //}

        //internal static void CreateNewTodosList(string title, IEnumerable<TodoViewModel> todos)
        //{
        //    var listModel = new TodolistModel()
        //    {
        //        Title = title,
        //        Todos = todos.Select(t => new TodoModel()
        //        {
        //            Text = t.Text
        //        })
        //    };

        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;

        //    var response =
        //        HttpRequester.Post<ListCreatedModel>(BaseServicesUrl + "lists", listModel, headers);
        //}

        //internal static IEnumerable<TodoListViewModel> GetTodoLists()
        //{
        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;

        //    var todoListsModels =
        //        HttpRequester.Get<IEnumerable<TodolistModel>>(BaseServicesUrl + "lists", headers);
        //    return todoListsModels.
        //        AsQueryable().
        //         Select(model => new TodoListViewModel()
        //         {
        //             Id = model.Id,
        //             Title = model.Title,
        //             Todos = model.Todos.AsQueryable().Select(todo => new TodoViewModel()
        //             {
        //                 Id = todo.Id,
        //                 Text = todo.Text,
        //                 IsDone = todo.IsDone
        //             })
        //         });
        //}

        //internal static void ChangeState(int todoId)
        //{
        //    var headers = new Dictionary<string, string>();
        //    headers["X-accessToken"] = AccessToken;

        //    HttpRequester.Put(BaseServicesUrl + "todos/" + todoId, headers);
        //}


        internal static IEnumerable<MovieModel> GetMoviesByKeyword(string p)
        {
            var response = HttpRequester.Get<IEnumerable<MovieModel>>(BaseServicesUrl + "movies?keyword=" + p);
            return response;
        }

        internal static ProjectionDetailsModel getProjectionById(int p)
        {
            var response = HttpRequester.Get<ProjectionDetailsModel>(BaseServicesUrl + "projections/" + p);
            return response;
        }

        internal static ReservationModel CreateReservation(CreateReservationModel newReservation, int p)
        {
            var response = HttpRequester.Post <ReservationModel>(BaseServicesUrl + "projections/" + p, newReservation);
            return response;
        }
    }
}
