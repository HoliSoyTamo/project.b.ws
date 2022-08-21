﻿using Microsoft.AspNetCore.Mvc;
using project.b.entity.Entity;
using project.b.service.Service;
using project.b.support.SupportDto;

namespace project.b.ws.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {

        #region "Variable"
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }
        #endregion

        #region "No Transaccionales"
        [HttpGet]
        [Route("ListarProductos")]
        public IActionResult ListarProductos()
        {
            var response = new Response<List<ProductoEntity>>();
            response = _productoService.ListarProductos();

            if (!response.IsSuccess)
            {
                if (response.ErrorDetails.StatusCode == 404)
                    return NotFound(response);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }
        #endregion

        #region "Transaccionales"
        [HttpPost]
        [Route("EditarProducto")]
        public IActionResult EditarProducto(ProductoEntity producto)
        {
            var response = new Response<string>();
            response = _productoService.EditarProducto(producto);

            if (!response.IsSuccess)
            {
                if (response.ErrorDetails.StatusCode == 404)
                    return NotFound(response);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Route("EliminarProducto")]
        public IActionResult EliminarProducto(ProductoEntity producto)
        {
            var response = new Response<string>();
            response = _productoService.EliminarProducto(producto.id);

            if (!response.IsSuccess)
            {
                if (response.ErrorDetails.StatusCode == 404)
                    return NotFound(response);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }


        [HttpPost]
        [Route("RegistrarProducto")]
        public IActionResult RegistrarProducto(ProductoEntity periodo)
        {
            var response = new Response<string>();
            response = _productoService.RegistrarProducto(periodo);

            if (!response.IsSuccess)
            {
                if (response.ErrorDetails.StatusCode == 404)
                    return NotFound(response);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            return Ok(response);
        }

        #endregion

    }
}
