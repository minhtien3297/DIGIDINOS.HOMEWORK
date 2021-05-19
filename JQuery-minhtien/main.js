/**
 * Lay data truyen vao table
 */
$(document).ready(function () {
  var table = $("#datatable").DataTable({
    columnDefs: [
      {
        targets: [3, 6],
        type: "dom-text",
        render: function (data, type, row, meta) {
          return (
            "<input type='text' value='" + data + "' class='form-control'>"
          );
        },
      },
      {
        targets: [2],
        render: function (data) {
          return selectPositions(data);
        },
      },
      {
        targets: [5],
        render: function (data) {
          return selectOffices(data);
        },
      },
      {
        targets: [4],
        type: "dom-text",
        render: function (data, type, row, meta) {
          return (
            "<input type='date' value='" + data + "' class='form-control'>"
          );
        },
      },
    ],
    select: true,
    paging: false,
    data: dataJson.users,
    columns: [
      { data: "id" },
      { data: "name" },
      {
        data: "position",
        defaultContent: '<select class="position form-control"></select>',
      },
      { data: "salary" },
      {
        data: "start_date",
      },
      {
        data: "office",
        defaultContent: '<select class="office form-control"></select>',
      },
      { data: "extn" },
      {
        data: "null",
        defaultContent:
          '<input type="button" value="Delete" id="btndelete" class="btn btn-danger form-control"/>',
      },
    ],
  });

  /**
   * Delete row
   */
  $("#datatable").on("click", "#btndelete", function () {
    $(this).closest("tr").remove();
  });

  /**
   * Tao dropdown list position
   */
  $.each(dataJson.positions, function () {
    var option = $("<option></option>");
    option.attr("value", this.id).text(this.name);
    $(".position").append(option);
  });

  /**
   * Tao dropdown list office
   */
  $.each(dataJson.offices, function () {
    var option = $("<option></option>");
    option.attr("value", this.id).text(this.name);
    $(".office").append(option);
  });

  /**
   * Lay position name theo id
   * @param {number} selItem
   */
  function selectPositions(selItem) {
    var sel = "<select class='form-control'>";
    $.each(dataJson.positions, function () {
      if (this.id == selItem) {
        sel +=
          "<option selected value = '" +
          this.id +
          "' >" +
          this.name +
          "</option>";
      } else sel += "<option  value = '" + this.id + "' >" + this.name + "</option>";
      console.log(sel);
    });
    sel += "</select>";

    return sel;
  }

  /**
   * Lay office name theo id
   * @param {number} selItem
   */
  function selectOffices(selItem) {
    var sel = "<select class='form-control'>";
    $.each(dataJson.offices, function () {
      if (this.id == selItem) {
        sel +=
          "<option selected value = '" +
          this.id +
          "' >" +
          this.name +
          "</option>";
      } else sel += "<option  value = '" + this.id + "' >" + this.name + "</option>";
      console.log(sel);
    });
    sel += "</select>";

    return sel;
  }

  /**
   * Lay data gan len card detail
   */
  $("#datatable tbody").on("click", "tr", function () {
    table.$("tr.selected").removeClass("selected");
    $(this).addClass("selected");
    var data = table.row(this).data();
    $(".name").val(data.id);
    $(".position").val(data.position);
    $(".salary").val(data.salary);
    $(".date").val(data.start_date);
    $(".office").val(data.office);
    $(".extn").val(data.extn);
  });

  /**
   * highlight selected row
   */
  $(function () {
    $("#datatable").on("click", "tbody tr", function (event) {
      $(this).addClass("highlight").siblings().removeClass("highlight");
    });
  });

  /**
   * Search id and name
   */
  $(".search").on("click", function () {
    table.search("");
    $(".search-box").each(function () {
      if (this.value.length > 0) {
        table.column($(this).data("columnIndex")).search(this.value);
      }
    });
    table.draw();
  });

  /**
   * Clear id and name
   */
  $(".clear").on("click", function () {
    $("#searchId").val("");
    $("#searchName").val("");
  });

  /**
   * Save id and name
   */
  $(".save").on("click", function () {
    var data = table.rows().data();
    console.log(data);
  });
});
