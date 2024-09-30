using Fekra_ApiLayer.Common;
using Fekra_BusinessLayer.services;
using Fekra_DataAccessLayer.models.Branches;
using Fekra_DataAccessLayer.models.Materials;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fekra_ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        // completed testing.
        [HttpGet("GetMaterialsWhereHaveTypicalQuestions/{branchId}", Name = "GetMaterialsWhereHaveTypicalQuestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetMaterialsWhereHaveTypicalQuestionsAsync(int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_MaterialsWhereHaveTypicalQuestions>? materials = await cls_Materials.GetMaterialsWhereHaveTypicalQuestionsByBranchAsync(branchId);

                if (materials == null)
                    return NotFound(new ApiResponse(true, "Not materials found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Materials = materials,
                                count = materials.Count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetAllMaterials", Name = "GetAllMaterials")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllMaterialsAsync()
        {
            try
            {
                List<md_Materials>? materials = await cls_Materials.GetAllAsync();

                if (materials == null)
                    return NotFound(new ApiResponse(true, "Not materials found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Materials = materials,
                                count = materials.Count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetMaterialsByBranch/{branchId}", Name = "GetMaterialsByBranch")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetMaterialsByBranchAsync([FromRoute] int branchId)
        {
            if (branchId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid branch ID.", new { }));

            try
            {
                List<md_Materials>? materials = await cls_Materials.GetByBranchAsync(branchId);

                if (materials == null)
                    return NotFound(new ApiResponse(true, "Not materials found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Materials = materials,
                                count = materials.Count
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("GetMaterialById/{materialId}", Name = "GetMaterialById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetMaterialByIdAsync(int materialId)
        {
            if (materialId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid material ID.", new { }));

            try
            {
                md_Materials? material = await cls_Materials.GetByIdAsync(materialId);

                if (material == null)
                    return NotFound(new ApiResponse(true, "Material not found.", new { }));

                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            "Success",
                            new
                            {
                                Material = material
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpGet("IsMaterialHasRelations/{materialId}", Name = "IsMaterialHasRelations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> IsMaterialHasRelationsAsync([FromRoute] int materialId)
        {
            if (materialId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid material ID.", new { }));

            try
            {
                bool isHasRelations = await cls_Materials.IsHasRelationsAsync(materialId);
                return Ok
                    (
                        new ApiResponse
                        (
                            true,
                            isHasRelations ? "The material has relations." : "The material does not has relations.",
                            new
                            {
                                HasRelations = isHasRelations
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpDelete("DeleteMaterial/{materialId}/{byAdmin}", Name = "DeleteMaterial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> DeleteMaterialAsync([FromRoute] int materialId, [FromRoute] int byAdmin)
        {

            if (materialId <= 0)
                return BadRequest(new ApiResponse(false, "Invalid material ID.", new { }));

            if (byAdmin <= 0)
                return BadRequest(new ApiResponse(false, "Invalid byAdmin.", new { }));

            try
            {
                bool response = await cls_Materials.DeleteAsync(materialId, byAdmin);
                if (response)
                    return Ok
                        (
                            new ApiResponse
                            (
                                true,
                                "Success.",
                                new { Response = response }
                            )
                        );

                return BadRequest
                    (
                        new ApiResponse
                        (
                            true,
                            "Please verify the material ID and byAdmin.",
                            new { Response = response }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpPost("NewMaterial", Name = "NewMaterial")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> NewMaterialAsync([FromBody] md_NewMaterial material)
        {
            if (!cls_Materials.ValidateObj_NewMode(material))
                return BadRequest(new ApiResponse(false, "Invalid material data", new { }));

            try
            {
                int insertedId = await cls_Materials.NewAsync(material);

                if (insertedId <= 0)
                    return BadRequest(new ApiResponse(false, "Material doesn't inserted successfully.", new { }));

                return CreatedAtRoute
                    (
                        "GetMaterialById",
                        new
                        {
                            materialId = insertedId
                        },
                        new ApiResponse
                        (
                            true,
                            "Material inserted successfully.",
                            new
                            {
                                Material = await cls_Materials.GetByIdAsync(insertedId)
                            }
                        )
                    );
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }

        // completed testing.
        [HttpPut("UpdateMaterial", Name = "UpdateMaterial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateMaterialAsync([FromBody] md_UpdateMaterial material)
        {
            if (!cls_Materials.ValidateObj_UpdateMode(material))
                return BadRequest(new ApiResponse(false, "Invalid material data", new { }));

            try
            {
                bool response = await cls_Materials.UpdateAsync(material);

                if (!response)
                    return BadRequest(new ApiResponse(false, "Material doesn't updated successfully.", new { }));

                return Ok(new ApiResponse(true, "Material updated successfully.", new { }));
            }
            catch
            {
                return StatusCode
                    (
                        500,
                        new ApiResponse
                        (
                            false,
                            "An error occurred while processing your request.",
                            new { }
                        )
                    );
            }
        }
    }
}
