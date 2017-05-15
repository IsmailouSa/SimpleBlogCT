$("[data-slug]").each(function () {
    var $this = $(this);
    var $sendSlugFrom = $($this.data("slug"));

    $sendSlugFrom.keyup(function () {
        var slug = $sendSlugFrom.val();
        slug = slug.replace(/[^a-zA-Z0-9\s]/g, "");
        slug = slug.toLowerCase();
        slug = slug.replace(/\s+/g, "-");

        if (slug.charAt(slug.length - 1) == "-")
            slug.substr(0, slug.length - 1);

        $this.val(slug);
    });
});