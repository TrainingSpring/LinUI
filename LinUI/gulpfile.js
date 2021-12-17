var gulp = require("gulp"),
    cleanCss = require("gulp-clean-css"),
    less = require("gulp-less"),
    concat = require("gulp-concat"),
    minify = require("gulp-minify")
    ;

gulp.task("wwwroot", function () {
    return gulp.src('wwwroot/**/*.less')
        .pipe(less())
        .pipe(cleanCss({ compatibility:  'ie8' }))
        .pipe(gulp.dest('wwwroot/'));
});
gulp.task("components", function () {
    return gulp.src('Components/**/*.less')
        .pipe(less())
        .pipe(cleanCss({ compatibility:  'ie8' }))
        .pipe(gulp.dest('Components/'));
});
gulp.task('default', gulp.parallel('wwwroot', 'components'), function () { });
/*

gulp.task("concatJs",function () {
    return gulp.src("wwwroot/js/!*.js")
        .pipe(concat("LinUI.concat.js"))
        .pipe(minify())
        .pipe(gulp.dest("wwwroot/js/LinUI.min.js"))
})
gulp.task("concatComponentsJs",function () {
    return gulp.src("Components/!**!/!*.js")
        .pipe(concat("LinUI.components.concat.js"))
        .pipe(minify())
        .pipe(gulp.dest("wwwroot/js/LinUI.components.min.js"))
})*/
