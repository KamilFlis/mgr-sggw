package com.sggw.jwttokenauthdemo.config;

import com.sggw.jwttokenauthdemo.security.JWTAuthenticationFilter;
import com.sggw.jwttokenauthdemo.security.JWTAuthorizationFilter;
import com.sggw.jwttokenauthdemo.security.SecurityConstants;
import com.sggw.jwttokenauthdemo.service.MyUserDetailsService;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.access.hierarchicalroles.RoleHierarchy;
import org.springframework.security.access.hierarchicalroles.RoleHierarchyImpl;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.ProviderManager;
import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.web.SecurityFilterChain;

import java.util.Arrays;

@Configuration
@EnableWebSecurity
@EnableMethodSecurity
public class SecurityConfig {

    @Bean
    public SecurityFilterChain securityFilterChain(HttpSecurity http) throws Exception {
        return http
                .anonymous()
                .and()
                .authorizeHttpRequests(authorize -> authorize
                        .requestMatchers("/api/register/")
                        .permitAll()
                        // .requestMatchers(HttpMethod.GET, "/api/users/**")
                        // .hasRole("ADMIN")
                        .anyRequest()
                        .authenticated()
                )
                .sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS)
                .and()
                .addFilter(jwtAuthenticationFilter(jwtAuthenticationManager()))
                .addFilter(jwtAuthorizationFilter(jwtAuthenticationManager()))
                .httpBasic().disable()
                .formLogin().disable()
                .csrf().disable()
                .cors().disable()
                .logout().disable()
                .build();
    }

    @Bean
    public DaoAuthenticationProvider authProvider() {
        DaoAuthenticationProvider authProvider = new DaoAuthenticationProvider();
        authProvider.setUserDetailsService(userDetailsService());
        authProvider.setPasswordEncoder(passwordEncoder());
        return authProvider;
    }

    @Bean
    public AuthenticationManager jwtAuthenticationManager() {
        return new ProviderManager(Arrays.asList(authProvider()));
    }

    @Bean
    public UserDetailsService userDetailsService() {
        return new MyUserDetailsService();
    }

    @Bean
    public PasswordEncoder passwordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Bean
    public RoleHierarchy roleHierarchy() {
        RoleHierarchyImpl roleHierarchy = new RoleHierarchyImpl();
        String hierarchy = "ROLE_ADMIN > ROLE_USER";
        roleHierarchy.setHierarchy(hierarchy);
        return roleHierarchy;
    }

    private JWTAuthenticationFilter jwtAuthenticationFilter(AuthenticationManager authenticationManager) throws Exception {
        JWTAuthenticationFilter filter = new JWTAuthenticationFilter(authenticationManager, userDetailsService());
        filter.setFilterProcessesUrl(SecurityConstants.SIGN_IN_URL);
//        filter.setAuthenticationFailureHandler(authenticationFailureHandler());
        return filter;
    }

    private JWTAuthorizationFilter jwtAuthorizationFilter(AuthenticationManager authenticationManager) {
        return new JWTAuthorizationFilter(authenticationManager, userDetailsService());
    }

    @Bean
    public AuthenticationManager authenticationManager(HttpSecurity http) throws Exception {
        AuthenticationManagerBuilder authenticationManagerBuilder = http.getSharedObject(AuthenticationManagerBuilder.class);
        authenticationManagerBuilder.userDetailsService(userDetailsService()).passwordEncoder(passwordEncoder());
        return authenticationManagerBuilder.build();
    }

}
